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
using Microsoft.Azure.Commands.KeyVault.Extensions;
using Microsoft.Azure.Commands.KeyVault.Progress;
using Microsoft.Azure.Commands.KeyVault.Utilities;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ProvisioningState = Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models.ProvisioningState;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class DeploymentClient
    {
        private IResourceManagementClient ResourceManagementClient = null;
        private List<DeploymentOperation> operations;

        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }
        public Action<string> VerboseLogger { get; set; }

        #region Constants
        public const string ErrorFormat = "Error: Code={0}; Message={1}\r\n";
        private const string DefaultTemplatePath = "Microsoft.Azure.Commands.KeyVault.Resources.keyvaultTemplate.json";
        #endregion

        public DeploymentClient(IAzureContext context)
        {
            ResourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        #region Deployment-related METHODS

        //fixme return database object
        public void CreateSqlDatabase(string resourceGroupName, string parameterSet, Deployment deployment, AzurePSCmdlet cmdlet = null)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            string deploymentName = GenerateDeploymentName(parameterSet);
            var existed = ResourceManagementClient.Deployments.CheckExistence(resourceGroupName, deploymentName);

            //WriteInfo("Validating KeyVault creation...", cmdlet);
            this.RunDeploymentValidation(resourceGroupName, deploymentName, deployment, cmdlet);//fixme
            this.BeginDeployment(deploymentName, resourceGroupName, deployment, cmdlet);
            var dep = ProvisionDeploymentStatus(deploymentName, resourceGroupName, deployment, cmdlet, existed).ToPSDeployment(resourceGroupName: resourceGroupName);

            //fixme return sqldatabase
            //return GetVault(parameters.Name, parameters.ResourceGroupName);
        }

        private void WriteInfo(string s, Cmdlet cmdlet)
        {
            string statusMessage = s;
            var clearMessage = new string(' ', statusMessage.Length);
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var clearInformation = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            var tags = new[] { "PSHOST" };
            cmdlet.WriteInformation(information, tags);
        }

        private void WriteDeploymentProgress(string deploymentName, string resourceGroupName, DeploymentOperationErrorInfo deploymentOperationError)
        {
            var result = ListDeploymentOperations(resourceGroupName, deploymentName);
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

        public DeploymentExtended ProvisionDeploymentStatus(string deploymentName, string resourceGroupName, Deployment deployment, AzurePSCmdlet cmdlet = null, bool existed = false)
        {
            operations = new List<DeploymentOperation>();
            ProvisioningState[] status = new ProvisioningState[] { ProvisioningState.Canceled, ProvisioningState.Succeeded, ProvisioningState.Failed };
            Func<Task<AzureOperationResponse<DeploymentExtended>>> getDeploymentFunc = () => ResourceManagementClient.Deployments.GetWithHttpMessagesAsync(resourceGroupName, deploymentName);
            var deploymentOperationError = new DeploymentOperationErrorInfo();
            Action writeProgressAction = () => this.WriteDeploymentProgress(deploymentName, resourceGroupName, deploymentOperationError);

            int progressBarTimeSpan = 220;
            if (existed) { progressBarTimeSpan = 20; }
            int step = 5;
            int phaseOne = 400;
            var downloadStatus = new ProgressStatus(0, progressBarTimeSpan);
            Program.SyncOutput = new PSSyncOutputEvents(cmdlet);

            DeploymentExtended deploymentExtended = null;

            ProgressTracker progressTracker = new ProgressTracker(downloadStatus, Program.SyncOutput.ProgressOperationStatus, Program.SyncOutput.ProgressOperationComplete);
            do
            {
                if (writeProgressAction != null)
                {
                    writeProgressAction();
                }
                var getDeploymentTask = getDeploymentFunc();
                var getResult = getDeploymentTask.ConfigureAwait(false).GetAwaiter().GetResult();

                var actionName = "Creation in progress...";
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
                progressTracker.Update(actionName);
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
                if (operation.Properties.TargetResource?.ResourceType?.Equals(Constants.MicrosoftResourcesDeploymentType, StringComparison.OrdinalIgnoreCase) == true)
                {
                    HttpStatusCode statusCode;
                    Enum.TryParse<HttpStatusCode>(operation.Properties.StatusCode, out statusCode);
                    if (!statusCode.IsClientFailureRequest())
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
        private IPage<DeploymentOperation> ListDeploymentOperations(string resourceGroupName, string deploymentName)
        {
            return ResourceManagementClient.DeploymentOperations.List(resourceGroupName, deploymentName, null);
        }
        private List<DeploymentOperation> GetNestedDeploymentOperations(string deploymentId)
        {
            var resourceGroupName = ResourceIdUtility.GetResourceGroupName(deploymentId);
            var deploymentName = ResourceIdUtility.GetDeploymentName(deploymentId);
            
            if (ResourceManagementClient.Deployments.CheckExistence(resourceGroupName, deploymentName) == true)
            {
                var result = this.ListDeploymentOperations(resourceGroupName, deploymentName);

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

        private string GenerateDeploymentName(string parameterSetName)
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

        private void BeginDeployment(string deploymentName, string resourceGroupName, Deployment deployment, AzurePSCmdlet cmdlet = null)
        {
            bool threadCompleted = false;
            var progressBarTimeSpan = 65;
            Program.SyncOutput = new PSSyncOutputEvents(cmdlet);
            var creationStatus = new ProgressStatus(0, progressBarTimeSpan);
            var actionName = "Starting creating KeyVault...";
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
            ProgressTracker progressTracker = new ProgressTracker(creationStatus, Program.SyncOutput.ProgressOperationStatus, Program.SyncOutput.ProgressOperationComplete);
            while (!threadCompleted)
            {
                progressTracker.Update(actionName);
                Thread.Sleep(500);
            }
        }

        private void RunDeploymentValidation(string resourceGroupName, string deploymentName, Deployment deployment, AzurePSCmdlet cmdlet = null)
        {
            TemplateValidationInfo validationResult = null;
            var progressBarTimeSpan = 50;
            var downloadStatus = new ProgressStatus(0, progressBarTimeSpan);
            var actionName = "Validating KeyVault";
            Program.SyncOutput = new PSSyncOutputEvents(cmdlet);
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
                        validationResult = this.GetTemplateValidationResult(resourceGroupName, deploymentName, deployment);
                    }
                    finally
                    {
                        onComplete();
                    }
                });
            validationThread.Start();
            ProgressTracker progressTracker = new ProgressTracker(downloadStatus, Program.SyncOutput.ProgressOperationStatus, Program.SyncOutput.ProgressOperationComplete);
            while (!threadCompleted)
            {
                progressTracker.Update(actionName);
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

        private TemplateValidationInfo GetTemplateValidationResult(string resourceGroupName, string deploymentName, Deployment deployment)
        {
            try
            {
                // WriteVerbose("Start validating");
                var validationResult = this.ValidateDeployment(resourceGroupName, deploymentName, deployment);
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

        private DeploymentValidateResult ValidateDeployment(string resourceGroupName, string deploymentName, Deployment deployment)
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
        /// <param name="parameters"></param>
        /// <param name="kvParameters"></param>
        /// <param name="networkRuleSet"></param>
        /// <returns></returns>
        public virtual PSWhatIfOperationResult ExecuteDeploymentWhatIf(PSDeploymentWhatIfCmdletParameters parameters, VaultCreationOrUpdateParameters kvParameters, PSKeyVaultNetworkRuleSet networkRuleSet = null)
        {
            IDeploymentsOperations deployments = this.ResourceManagementClient.Deployments;
            DeploymentWhatIf deploymentWhatIf = parameters.ToDeploymentWhatIf(parameters, kvParameters, networkRuleSet);
            ScopedDeploymentWhatIf scopedDeploymentWhatIf = new ScopedDeploymentWhatIf(deploymentWhatIf.Location, deploymentWhatIf.Properties);

            try
            {
                WhatIfOperationResult whatIfOperationResult = null;
                whatIfOperationResult = deployments.WhatIf(parameters.ResourceGroupName, parameters.DeploymentName, deploymentWhatIf.Properties);

               if (parameters.ExcludeChangeTypes != null)
                {
                    whatIfOperationResult.Changes = whatIfOperationResult.Changes
                        .Where(change => parameters.ExcludeChangeTypes.All(changeType => changeType != change.ChangeType))
                        .ToList();
                }

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
