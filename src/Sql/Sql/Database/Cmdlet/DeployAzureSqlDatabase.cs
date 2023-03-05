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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;

using Newtonsoft.Json;

using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Database
    /// </summary>
    [Cmdlet("Deploy", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low, DefaultParameterSetName = "NewDatabaseNewServerNewElasticPool"), OutputType(typeof(AzureSqlDatabaseModel))]
    //[global::Microsoft.Azure.PowerShell.Cmdlets.Sql.Description(@"Removes a content from CDN.")]
    public partial class DeployAzureSqlDatabase : DeploymentCreateCmdlet
    {
        /// <summary>
        /// Gets or sets the name of the database to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL Database to create.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName
        {
            get
            {
                return (string)GetTemplateParameterValue("databaseName");
            }
            set
            {
                CreateTemplateParameterValue("databaseName", value);
            }
        }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName
        {
            get
            {
                return (string)GetTemplateParameterValue("resourceGroupName");
            }
            set
            {
                CreateTemplateParameterValue("resourceGroupName", value);
            }
        }

        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Database Server the database is in.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName
        {
            get
            {
                return (string)GetTemplateParameterValue("serverName");
            }
            set
            {
                CreateTemplateParameterValue("serverName", value);
            }
        }

        [Parameter(Mandatory = true, HelpMessage = "The location to store deployment data.")]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        #region hideParameterFromBaseCmdlet
        private new Hashtable TemplateParameterObject { get; set; }
        private new string TemplateParameterFile { get; set; }
        private new string TemplateParameterUri { get; set; }
        private new Hashtable TemplateObject { get; set; }
        private new string TemplateFile { get; set; }
        private new string TemplateUri { get; set; }
        private new string TemplateSpecId { get; set; }
        private new SwitchParameter SkipTemplateParameterPrompt { get; set; }
        private new string QueryString { get; set; }
        private new SwitchParameter Pre { get; set; }
        #endregion

        private const string templateFile = "PortalTemplate.json";

        private const string templateParameterFile = "Portal.Parameter.json";

        protected override PSDeploymentCmdletParameters DeploymentParameters => new PSDeploymentCmdletParameters()
        {
            ScopeType = DeploymentScopeType.ResourceGroup,
            //Location = this.Location,
            ResourceGroupName = this.ResourceGroupName,
            DeploymentName = GenerateDeploymentName(this.ParameterSetName),
            DeploymentMode = DeploymentMode.Incremental,
            //QueryString = this.QueryString,
            //TemplateFile = this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
            TemplateObject = JsonConvert.DeserializeObject<Hashtable>(GetArmTemplateContent(templateFile)),
            //TemplateSpecId = TemplateSpecId,
            TemplateParameterObject = GetTemplateParameterObject(),
            //ParameterUri = this.TemplateParameterUri,
            DeploymentDebugLogLevel = GetDeploymentDebugLogLevel("responsecontent"),
            //Tags = TagsHelper.ConvertToTagsDictionary(this.Tag)
        };

        protected override PSDeploymentWhatIfCmdletParameters WhatIfParameters => new PSDeploymentWhatIfCmdletParameters(
            DeploymentScopeType.ResourceGroup,
            resourceGroupName: this.ResourceGroupName,
            //location: this.Location,
            deploymentName: GenerateDeploymentName(this.ParameterSetName),
            mode: DeploymentMode.Incremental,
            //queryString: this.QueryString,
            //resourceGroupName: this.ResourceGroupName,
            //templateUri: this.TemplateUri ?? this.TryResolvePath(this.TemplateFile),
            templateObject: JsonConvert.DeserializeObject<Hashtable>(GetArmTemplateContent(templateFile)),
            //templateSpecId: TemplateSpecId,
            //templateParametersUri: this.TemplateParameterUri,
            templateParametersObject: GetTemplateParameterObject(),
            resultFormat: WhatIfResultFormat.FullResourcePayloads);

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        protected override void OnProcessRecord()
        {
            //base.OnProcessRecord();
            ModelAdapter = InitModelAdapter();
            WriteObject(TransformModelToOutputObject(GetEntity()));
        }

        protected override ConfirmImpact ConfirmImpact => ((CmdletAttribute)Attribute.GetCustomAttribute(
            typeof(DeployAzureSqlDatabase),
            typeof(CmdletAttribute))).ConfirmImpact;

        protected override bool ShouldSkipConfirmationIfNoChange()
        {
            throw new NotImplementedException();
        }

        //private DeploymentClient _client = null;

        //internal DeploymentClient TemplateDeploymentClient
        //{
        //    get
        //    {
        //        if (_client == null)
        //        {
        //            _client = new DeploymentClient(DefaultContext, ResourceGroupName, ParameterSetName);
        //        }
        //        return _client;
        //    }
        //}

        //Deployment GetDeployment()
        //{
        //    const string DefaultTemplatePath = "Microsoft.Azure.Commands.Sql.Resources.NewDatabaseNewServerNewElasticPool.json";
        //    string templateContent = null;

        //    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(DefaultTemplatePath))
        //    using (var reader = new StreamReader(stream))
        //    {
        //        templateContent = reader.ReadToEnd();
        //    }

        //    var deployment = new Deployment()
        //    {
        //        Location = Serverlocation,
        //        Properties = new DeploymentProperties
        //        {
        //            Mode = DeploymentMode.Incremental,
        //            Template = templateContent,
        //            Parameters = TemplateParameterObject
        //        }
        //    };
        //    return deployment;
        //}

        //DeploymentWhatIf GetDeploymentWhatIf()
        //{
        //    const string DefaultTemplatePath = "Microsoft.Azure.Commands.Sql.Resources.NewDatabaseNewServerNewElasticPool.json";
        //    string templateContent = null;

        //    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(DefaultTemplatePath))
        //    using (var reader = new StreamReader(stream))
        //    {
        //        templateContent = reader.ReadToEnd();
        //    }

        //    var deploymentWhatIf = new DeploymentWhatIf()
        //    {
        //        Location = Serverlocation,

        //        Properties = new DeploymentWhatIfProperties()
        //        {
        //            Mode = DeploymentMode.Incremental,
        //            WhatIfSettings = new DeploymentWhatIfSettings(WhatIfResultFormat.FullResourcePayloads)
        //        }
        //    };
        //    return deploymentWhatIf;
        //}
    }
}
