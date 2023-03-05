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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    public partial class DeployAzureSqlDatabase
    {
        private Dictionary<string, object> templateParameterObject = new Dictionary<string, object>();

        private void CreateTemplateParameterValue(string name, object value)
        {
            templateParameterObject[name] = value;
        }

        private object GetTemplateParameterValue(string name)
        {
            return templateParameterObject.ContainsKey(name) ? templateParameterObject[name] : null;
        }

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
        private string GetArmTemplateContent(string templateName)
        {
            var resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var resourceName = resourceNames.FirstOrDefault(str => str.EndsWith(templateName));
            string template;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    template = reader.ReadToEnd();
                }
            }

            return template;
        }

        private Hashtable GetTemplateParameterObject()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(str => str.EndsWith(templateParameterFile));
            Dictionary<string, TemplateFileParameterV1> parameters = null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var content = reader.ReadToEnd();
                    try
                    {
                        parameters = JsonConvert.DeserializeObject<Dictionary<string, TemplateFileParameterV1>>(content);
                    }
                    catch (JsonSerializationException)
                    {
                        var parametersv2 = JsonConvert.DeserializeObject<TemplateFileParameterV2>(content);
                        parameters = new Dictionary<string, TemplateFileParameterV1>(parametersv2.Parameters);
                    }
                }
            }
            var parameterObject = new Hashtable();
            parameters.ForEach(dp =>
            {
                var parameter = new Hashtable();
                if (dp.Value.Value != null)
                {
                    parameter.Add("value", dp.Value.Value);
                }
                if (dp.Value.Reference != null)
                {
                    parameter.Add("reference", dp.Value.Reference);
                }

                parameterObject[dp.Key] = parameter;
            });

            templateParameterObject.ForEach(item => parameterObject[item.Key] = new Hashtable { { "value", item.Value } });
            return parameterObject;
        }

        private AzureSqlDatabaseAdapter ModelAdapter;

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        private AzureSqlDatabaseCreateOrUpdateModel GetEntity()
        {
            // We try to get the database.  Since this is a create, we don't want the database to exist
            try
            {
                ModelAdapter.GetDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no database with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The database already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.DatabaseNameExists, this.DatabaseName, this.ServerName),
                "DatabaseName");
        }

        /// <summary>
        /// Strips away the create or update properties from the model so that just the regular properties
        /// are written to cmdlet output.
        /// </summary>
        protected object TransformModelToOutputObject(AzureSqlDatabaseCreateOrUpdateModel model)
        {
            return model.Database;
        }

        private AzureSqlDatabaseAdapter InitModelAdapter()
        {
            return new AzureSqlDatabaseAdapter(DefaultProfile.DefaultContext);
        }
    }
}
