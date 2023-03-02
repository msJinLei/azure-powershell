// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Cmdlets.Sql.Helpers.Resources;
using Microsoft.Azure.PowerShell.Cmdlets.Sql.Helpers.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Sql.Resources.Extensions;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

using Microsoft.Azure.Commands.Sql.Database.Sandbox;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.Database.Services
{
    public class DeploymentClient
    {
        private IResourceManagementClient ResourceManagementClient = null;
        private List<DeploymentOperation> operations;
        private string resourceGroupName = null;
        private string deploymentName = null;

        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }
        public Action<string> VerboseLogger { get; set; }

        #region Constants
        public const string ErrorFormat = "Error: Code={0}; Message={1}\r\n";
        private const string DefaultTemplatePath = "Microsoft.Azure.Commands.Sql.Resources.keyvaultTemplate.json";
        /// <summary>
        /// The deployments resource type.
        /// </summary>
        internal static readonly string MicrosoftResourcesDeploymentType = "Microsoft.Resources/deployments";
        internal static readonly string ResourceGroups = "ResourceGroups";
        internal static readonly string Providers = "Providers";
        #endregion

        #region extension
        #endregion

        #region utility
        private static string GenerateDeploymentName(string parameterSetName)
        {
            if (!string.IsNullOrEmpty(parameterSetName))
            {
                return parameterSetName + DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            }
            else
            {
                return Guid.NewGuid().ToString();
            }
        }

        private static bool IsClientFailureRequest(int statusCode)
        {
            return statusCode == 505 || statusCode == 501 || (statusCode >= 400 && statusCode < 500 && statusCode != 408);
        }
        #endregion

        public DeploymentClient(IAzureContext context, string resourceGroupName, string parameterSetName)
        {
            this.resourceGroupName = resourceGroupName;
            this.deploymentName = GenerateDeploymentName(parameterSetName);
            ResourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        #region Deployment-related METHODS

        public void CreateSqlDatabase(Deployment deployment, AzurePSCmdlet cmdlet = null)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new ArgumentNullException("resourceGroupName");
            }

            var existed = ResourceManagementClient.Deployments.CheckExistence(resourceGroupName, deploymentName);

            //WriteInfo("Validating Sql Database creation...", cmdlet);
            RunDeploymentValidation(deployment, cmdlet);//fixme
            BeginDeployment(deployment, cmdlet);
            var dep = ProvisionDeploymentStatus(deployment, cmdlet, existed).ToPSDeployment(resourceGroupName: resourceGroupName);

            //fixme: use output of the arm template and or get database in cmdlet
        }

        private void WriteInfo(string s, System.Management.Automation.Cmdlet cmdlet)
        {
            string statusMessage = s;
            var clearMessage = new string(' ', statusMessage.Length);
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var clearInformation = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            var tags = new[] { "PSHOST" };
            cmdlet.WriteInformation(information, tags);
        }

        private void WriteDeploymentProgress(DeploymentOperationErrorInfo deploymentOperationError)
        {
            var result = ListDeploymentOperations();
            var newOperations = GetNewOperations(operations, result);
            operations.AddRange(newOperations);

            foreach (DeploymentOperation operation in newOperations)
            {
                if (operation.Properties.ProvisioningState == ProvisioningState.Failed.ToString())
                {
                    deploymentOperationError.ProcessError(operation);
                }
            }
        }

        public DeploymentExtended ProvisionDeploymentStatus(Deployment deployment, AzurePSCmdlet cmdlet = null, bool existed = false)
        {
            operations = new List<DeploymentOperation>();
            var status = new ProvisioningState[] { ProvisioningState.Canceled, ProvisioningState.Succeeded, ProvisioningState.Failed };
            Func<Task<AzureOperationResponse<DeploymentExtended>>> getDeploymentFunc = () => ResourceManagementClient.Deployments.GetWithHttpMessagesAsync(resourceGroupName, deploymentName);
            var deploymentOperationError = new DeploymentOperationErrorInfo();

            if (existed)
            {
            }
            int step = 5;
            int phaseOne = 400;

            DeploymentExtended deploymentExtended = null;

            do
            {
                var getDeploymentTask = getDeploymentFunc();
                var getResult = getDeploymentTask.ConfigureAwait(false).GetAwaiter().GetResult();

                deploymentExtended = getResult.Body;
                var response = getResult.Response;
                if (response != null && response.Headers.RetryAfter != null && response.Headers.RetryAfter.Delta.HasValue)
                {
                    step = response.Headers.RetryAfter.Delta.Value.Seconds;
                }
                else
                {
                    step = phaseOne > 0 ? 5 : 60;
                }
            } while (!status.Any(s => s.ToString().Equals(deploymentExtended.Properties.ProvisioningState, StringComparison.OrdinalIgnoreCase)));

            if (deploymentOperationError.ErrorMessages.Count > 0)
            {
                WriteError(GetDeploymentErrorMessagesWithOperationId(deploymentOperationError,
                    deploymentName,
                    deploymentExtended?.Properties?.CorrelationId));
                throw new InvalidOperationException(deploymentOperationError.ErrorMessages.FirstOrDefault().Message);
            }

            return deploymentExtended;
        }

        public string GetDeploymentErrorMessagesWithOperationId(DeploymentOperationErrorInfo errorInfo, string deploymentName = null, string correlationId = null)
        {
            if (errorInfo.ErrorMessages.Count == 0)
                return String.Empty;

            var sb = new StringBuilder();

            int maxErrors = errorInfo.ErrorMessages.Count > DeploymentOperationErrorInfo.MaxErrorsToShow
               ? DeploymentOperationErrorInfo.MaxErrorsToShow
               : errorInfo.ErrorMessages.Count;

            // Add outer message showing the total number of errors.
            sb.AppendFormat("DeploymentOperationOuterError", deploymentName, maxErrors, errorInfo.ErrorMessages.Count);

            // Add each error message
            errorInfo.ErrorMessages
                .Take(maxErrors).ToList()
                .ForEach(m => sb
                    .AppendLine()
                    .AppendFormat("DeploymentOperationOuterError", m
                            .ToFormattedString())
                    .AppendLine());

            // Add correlationId
            sb.AppendLine().AppendFormat("DeploymentCorrelationId", correlationId);

            return sb.ToString();
        }

        private List<DeploymentOperation> GetNewOperations(List<DeploymentOperation> old, IPage<DeploymentOperation> current)
        {
            List<DeploymentOperation> newOperations = new List<DeploymentOperation>();
            foreach (DeploymentOperation operation in current)
            {
                DeploymentOperation operationWithSameIdAndProvisioningState = old.Find(o => o.OperationId.Equals(operation.OperationId) && o.Properties.ProvisioningState.Equals(operation.Properties.ProvisioningState));
                if (operationWithSameIdAndProvisioningState == null)
                {
                    newOperations.Add(operation);
                }

                //If nested deployment, get the operations under those deployments as well
                if (operation.Properties.TargetResource?.ResourceType?.Equals(MicrosoftResourcesDeploymentType, StringComparison.OrdinalIgnoreCase) == true)
                {
                    HttpStatusCode statusCode;
                    Enum.TryParse<HttpStatusCode>(operation.Properties.StatusCode, out statusCode);
                    if (!IsClientFailureRequest((int)statusCode))
                    {
                        var nestedDeploymentOperations = this.GetNestedDeploymentOperations(operation.Properties.TargetResource.Id);

                        foreach (DeploymentOperation op in nestedDeploymentOperations)
                        {
                            DeploymentOperation nestedOperationWithSameIdAndProvisioningState = newOperations.Find(o => o.OperationId.Equals(op.OperationId) && o.Properties.ProvisioningState.Equals(op.Properties.ProvisioningState));

                            if (nestedOperationWithSameIdAndProvisioningState == null)
                            {
                                newOperations.Add(op);
                            }
                        }
                    }
                }
            }

            return newOperations;
        }
        private IPage<DeploymentOperation> ListDeploymentOperations()
        {
            return ResourceManagementClient.DeploymentOperations.List(resourceGroupName, deploymentName, null);
        }
        private List<DeploymentOperation> GetNestedDeploymentOperations(string deploymentId)
        {
            var resourceIdentifier = new ResourceIdentifier(deploymentId);
            //fixme:check whether equivalent
            var resourceGroupName = resourceIdentifier.ResourceGroupName;
            var deploymentName = resourceIdentifier.ResourceType;

            if (ResourceManagementClient.Deployments.CheckExistence(resourceGroupName, deploymentName) == true)
            {
                var result = this.ListDeploymentOperations();

                return GetNewOperations(operations, result);
            }

            return new List<DeploymentOperation>();
        }

        private void WriteVerbose(string progress)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(progress);
            }
        }

        private void BeginDeployment(Deployment deployment, AzurePSCmdlet cmdlet = null)
        {
            bool threadCompleted = false;
            Action onComplete = () =>
            {
                threadCompleted = true;
            };
            var creationThread = new Thread(
                () =>
                {
                    try
                    {
                        ResourceManagementClient.Deployments.BeginCreateOrUpdate(resourceGroupName, deploymentName, deployment);
                    }
                    finally
                    {
                        onComplete();
                    }
                });
            creationThread.Start();
            // validationResult = this.GetTemplateValidationResult(parameters, deployment);
            while (!threadCompleted)
            {
                Thread.Sleep(500);
            }
        }

        private void RunDeploymentValidation(Deployment deployment, AzurePSCmdlet cmdlet = null)
        {
            TemplateValidationInfo validationResult = null;
            bool threadCompleted = false;

            Action onComplete = () =>
            {
                threadCompleted = true;
            };
            var validationThread = new Thread(
                () =>
                {
                    try
                    {
                        validationResult = this.GetTemplateValidationResult(deployment);
                    }
                    finally
                    {
                        onComplete();
                    }
                });
            validationThread.Start();
            while (!threadCompleted)
            {
                Thread.Sleep(500);
            }

            if (validationResult.Errors.Count != 0)
            {
                foreach (var error in validationResult.Errors)
                {
                    WriteError(string.Format(ErrorFormat, error.Code, error.Message));
                    if (error.Details != null && error.Details.Count > 0)
                    {
                        foreach (var innerError in error.Details)
                        {
                            DisplayInnerDetailErrorMessage(innerError);
                        }
                    }
                }
                throw new InvalidOperationException(validationResult.Errors.FirstOrDefault().Message);
            }
            else
            {
                WriteVerbose("TemplateValid");
            }
        }

        private TemplateValidationInfo GetTemplateValidationResult(Deployment deployment)
        {
            try
            {
                // WriteVerbose("Start validating");
                var validationResult = this.ValidateDeployment(deployment);
                // WriteVerbose("Got result.");
                return new TemplateValidationInfo(validationResult);
            }
            catch (Exception ex)
            {
                var error = HandleError(ex).FirstOrDefault();
                return new TemplateValidationInfo(new DeploymentValidateResult(error));
            }
        }

        private List<ErrorResponse> HandleError(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            ErrorResponse error = null;
            var innerException = HandleError(ex.InnerException);
            if (ex is CloudException)
            {
                var cloudEx = ex as CloudException;
                error = new ErrorResponse(cloudEx.Body?.Code, cloudEx.Body?.Message, cloudEx.Body?.Target, innerException);
            }
            else
            {
                error = new ErrorResponse(null, ex.Message, null, innerException);
            }

            return new List<ErrorResponse> { error };

        }

        private DeploymentValidateResult ValidateDeployment(Deployment deployment)
        {
            return ResourceManagementClient.Deployments.BeginValidate(resourceGroupName, deploymentName, deployment);
        }

        private void WriteError(string error)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(error);
            }
        }

        private void DisplayInnerDetailErrorMessage(ErrorResponse error)
        {
            WriteError(string.Format(ErrorFormat, error.Code, error.Message));
            if (error.Details != null)
            {
                foreach (var innerError in error.Details)
                {
                    DisplayInnerDetailErrorMessage(innerError);
                }
            }
        }

        /// <summary>
        /// Executes deployment What-If at the specified scope.
        /// </summary>
        /// <param name="deploymentWhatIf"></param>
        /// <returns></returns>
        public virtual PSWhatIfOperationResult ExecuteDeploymentWhatIf(DeploymentWhatIf deploymentWhatIf)
        {
            IDeploymentsOperations deployments = this.ResourceManagementClient.Deployments;
            ScopedDeploymentWhatIf scopedDeploymentWhatIf = new ScopedDeploymentWhatIf(deploymentWhatIf.Location, deploymentWhatIf.Properties);

            try
            {
                WhatIfOperationResult whatIfOperationResult = null;
                whatIfOperationResult = deployments.WhatIf(resourceGroupName, deploymentName, deploymentWhatIf.Properties);

                //fixme: assign values to ExcludeChangeTypes
                //if (parameters.ExcludeChangeTypes != null)
                // {
                //     whatIfOperationResult.Changes = whatIfOperationResult.Changes
                //         .Where(change => parameters.ExcludeChangeTypes.All(changeType => changeType != change.ChangeType))
                //         .ToList();
                // }

                return new PSWhatIfOperationResult(whatIfOperationResult);
            }
            catch (CloudException ce)
            {
                string errorMessage = $"{Environment.NewLine}{BuildCloudErrorMessage(ce.Body)}";
                throw new CloudException(errorMessage);
            }
        }

        private static string BuildCloudErrorMessage(CloudError cloudError)
        {
            if (cloudError == null)
            {
                return string.Empty;
            }

            IList<string> messages = new List<string>
            {
                $"{cloudError.Code} - {cloudError.Message}"
            };

            foreach (CloudError innerError in cloudError.Details)
            {
                messages.Add(BuildCloudErrorMessage(innerError));
            }

            return string.Join(Environment.NewLine, messages);
        }
        #endregion
    }
}
