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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;

using System.Collections;
using System.IO;
using System.Management.Automation;
using System.Reflection;

using Deployment = Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models.Deployment;
using DeploymentMode = Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models.DeploymentMode;
using DeploymentProperties = Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models.DeploymentProperties;

namespace Microsoft.Azure.Commands.KeyVault
{
    /// <summary>
    /// Create a SqlDatabase.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabase", SupportsShouldProcess = true)]
    [OutputType(typeof(PSKeyVault))]
    public partial class NewAzureSqlDatabase : AzureRMCmdlet
    {
        private DeploymentClient _client = null;

        internal DeploymentClient TemplateDeploymentClient
        {
            get
            {
                if (_client == null)
                {
                    _client = new DeploymentClient(DefaultContext);
                }
                return _client;
            }
        }

        private Hashtable parametersFromTemplate = new Hashtable();

        private void CreateTemplateParameterValue(string name, object value)
        {
            parametersFromTemplate[name] = new Hashtable { { "value", value } };
        }

        private object GetTemplateParameterValue(string name)
        {
            return parametersFromTemplate.Contains(name) ? parametersFromTemplate[name] : null;
        }

        [Parameter(Mandatory = true, HelpMessage = "")]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            const string DefaultTemplatePath = "Microsoft.Azure.Commands.KeyVault.Resources.NewDatabaseNewServerNewElasticPool.json";
            string templateContent = null;
            
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(DefaultTemplatePath))
            using (var reader = new StreamReader(stream))
            {
                templateContent = reader.ReadToEnd();
            }

            Deployment deployment = new Deployment()
            {
                Location = Serverlocation,
                Properties = new DeploymentProperties
                {
                    Mode = DeploymentMode.Incremental,
                    Template = templateContent,
                    Parameters = parametersFromTemplate
                }
            };
            TemplateDeploymentClient.CreateSqlDatabase(ResourceGroupName, ParameterSetName, deployment, this);
        }

        /*
        protected PSWhatIfOperationResult ExecuteWhatIf(VaultCreationOrUpdateParameters VaultCreationParameter)
        {
            const string statusMessage = "Getting the latest status of all resources...";
            var clearMessage = new string(' ', statusMessage.Length);
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var clearInformation = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            var tags = new[] { "PSHOST" };

            try
            {
                // Write status message.
                this.WriteInformation(information, tags);
                PSWhatIfOperationResult whatIfResult;
                // this.WhatIfParameters
                whatIfResult = TemplateDeploymentClient.ExecuteDeploymentWhatIf(this.WhatIfParameters, VaultCreationParameter);

                // Clear status before returning result.
                this.WriteInformation(clearInformation, tags);

                return whatIfResult;
            }
            catch (Exception)
            {
                // Clear status before on exception.
                this.WriteInformation(clearInformation, tags);
                throw;
            }
        }
        */
    }
}
