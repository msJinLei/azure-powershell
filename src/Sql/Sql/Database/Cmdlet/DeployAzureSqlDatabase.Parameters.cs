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

using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    /// <summary>
    /// Create a SqlDatabase.
    /// </summary>
    public partial class DeployAzureSqlDatabase
    {

        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Administratorlogin
        {
            get
            {
                return (string)GetTemplateParameterValue("administratorLogin");
            }
            set
            {
                CreateTemplateParameterValue("administratorLogin", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public SecureString Administratorloginpassword
        {
            get
            {
                return (SecureString)GetTemplateParameterValue("administratorLoginPassword");
            }
            set
            {
                CreateTemplateParameterValue("administratorLoginPassword", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public object Administrators
        {
            get
            {
                return (object)GetTemplateParameterValue("administrators");
            }
            set
            {
                CreateTemplateParameterValue("administrators", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Collation
        {
            get
            {
                return (string)GetTemplateParameterValue("collation");
            }
            set
            {
                CreateTemplateParameterValue("collation", value);
            }
        }

        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Skuname
        {
            get
            {
                return (string)GetTemplateParameterValue("skuName");
            }
            set
            {
                CreateTemplateParameterValue("skuName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Tier
        {
            get
            {
                return (string)GetTemplateParameterValue("tier");
            }
            set
            {
                CreateTemplateParameterValue("tier", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Poollimit
        {
            get
            {
                return (string)GetTemplateParameterValue("poolLimit");
            }
            set
            {
                CreateTemplateParameterValue("poolLimit", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public int Poolsize
        {
            get
            {
                return (int)GetTemplateParameterValue("poolSize");
            }
            set
            {
                CreateTemplateParameterValue("poolSize", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Perdatabaseperformancemin
        {
            get
            {
                return (string)GetTemplateParameterValue("perDatabasePerformanceMin");
            }
            set
            {
                CreateTemplateParameterValue("perDatabasePerformanceMin", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Perdatabaseperformancemax
        {
            get
            {
                return (string)GetTemplateParameterValue("perDatabasePerformanceMax");
            }
            set
            {
                CreateTemplateParameterValue("perDatabasePerformanceMax", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Serverlocation
        {
            get
            {
                return (string)GetTemplateParameterValue("serverLocation");
            }
            set
            {
                CreateTemplateParameterValue("serverLocation", value);
            }
        }

        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Elasticpoolname
        {
            get
            {
                return (string)GetTemplateParameterValue("elasticPoolName");
            }
            set
            {
                CreateTemplateParameterValue("elasticPoolName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Samplename
        {
            get
            {
                return (string)GetTemplateParameterValue("sampleName");
            }
            set
            {
                CreateTemplateParameterValue("sampleName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Zoneredundant
        {
            get
            {
                return (bool)GetTemplateParameterValue("zoneRedundant");
            }
            set
            {
                CreateTemplateParameterValue("zoneRedundant", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Licensetype
        {
            get
            {
                return (string)GetTemplateParameterValue("licenseType");
            }
            set
            {
                CreateTemplateParameterValue("licenseType", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Enableads
        {
            get
            {
                return (bool)GetTemplateParameterValue("enableADS");
            }
            set
            {
                CreateTemplateParameterValue("enableADS", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Allowazureips
        {
            get
            {
                return (bool)GetTemplateParameterValue("allowAzureIps");
            }
            set
            {
                CreateTemplateParameterValue("allowAzureIps", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public object Databasetags
        {
            get
            {
                return (object)GetTemplateParameterValue("databaseTags");
            }
            set
            {
                CreateTemplateParameterValue("databaseTags", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public object Servertags
        {
            get
            {
                return (object)GetTemplateParameterValue("serverTags");
            }
            set
            {
                CreateTemplateParameterValue("serverTags", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public object Elasticpooltags
        {
            get
            {
                return (object)GetTemplateParameterValue("elasticPoolTags");
            }
            set
            {
                CreateTemplateParameterValue("elasticPoolTags", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Enableva
        {
            get
            {
                return (bool)GetTemplateParameterValue("enableVA");
            }
            set
            {
                CreateTemplateParameterValue("enableVA", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "To enable vulnerability assessments, the user deploying this template must have an administrator or owner permissions.")]
        public bool Usevamanagedidentity
        {
            get
            {
                return (bool)GetTemplateParameterValue("useVAManagedIdentity");
            }
            set
            {
                CreateTemplateParameterValue("useVAManagedIdentity", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Flag for enabling vulnerability assessments with express configuration (storage less), the user deploying this template must have administrator or owner permissions.")]
        public bool Vastoragelessenabled
        {
            get
            {
                return (bool)GetTemplateParameterValue("vaStoragelessEnabled");
            }
            set
            {
                CreateTemplateParameterValue("vaStoragelessEnabled", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Enableprivateendpoint
        {
            get
            {
                return (bool)GetTemplateParameterValue("enablePrivateEndpoint");
            }
            set
            {
                CreateTemplateParameterValue("enablePrivateEndpoint", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointnestedtemplateid
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointNestedTemplateId");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointNestedTemplateId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointsubscriptionid
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointSubscriptionId");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointSubscriptionId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointresourcegroup
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointResourceGroup");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointResourceGroup", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointname
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointName");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointlocation
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointLocation");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointLocation", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointsubnetid
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointSubnetId");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointSubnetId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privatelinkservicename
        {
            get
            {
                return (string)GetTemplateParameterValue("privateLinkServiceName");
            }
            set
            {
                CreateTemplateParameterValue("privateLinkServiceName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privatelinkserviceserviceid
        {
            get
            {
                return (string)GetTemplateParameterValue("privateLinkServiceServiceId");
            }
            set
            {
                CreateTemplateParameterValue("privateLinkServiceServiceId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointvnetsubscriptionid
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointVnetSubscriptionId");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointVnetSubscriptionId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointvnetresourcegroup
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointVnetResourceGroup");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointVnetResourceGroup", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointvnetname
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointVnetName");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointVnetName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointsubnetname
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointSubnetName");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointSubnetName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Enableprivatednszone
        {
            get
            {
                return (bool)GetTemplateParameterValue("enablePrivateDnsZone");
            }
            set
            {
                CreateTemplateParameterValue("enablePrivateDnsZone", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privatelinkprivatednszonefqdn
        {
            get
            {
                return (string)GetTemplateParameterValue("privateLinkPrivateDnsZoneFQDN");
            }
            set
            {
                CreateTemplateParameterValue("privateLinkPrivateDnsZoneFQDN", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointdnsrecorduniqueid
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointDnsRecordUniqueId");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointDnsRecordUniqueId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privateendpointtemplatelink
        {
            get
            {
                return (string)GetTemplateParameterValue("privateEndpointTemplateLink");
            }
            set
            {
                CreateTemplateParameterValue("privateEndpointTemplateLink", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privatednsforprivateendpointtemplatelink
        {
            get
            {
                return (string)GetTemplateParameterValue("privateDnsForPrivateEndpointTemplateLink");
            }
            set
            {
                CreateTemplateParameterValue("privateDnsForPrivateEndpointTemplateLink", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privatednsforprivateendpointnictemplatelink
        {
            get
            {
                return (string)GetTemplateParameterValue("privateDnsForPrivateEndpointNicTemplateLink");
            }
            set
            {
                CreateTemplateParameterValue("privateDnsForPrivateEndpointNicTemplateLink", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Privatednsforprivateendpointipconfigtemplatelink
        {
            get
            {
                return (string)GetTemplateParameterValue("privateDnsForPrivateEndpointIpConfigTemplateLink");
            }
            set
            {
                CreateTemplateParameterValue("privateDnsForPrivateEndpointIpConfigTemplateLink", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Allowclientip
        {
            get
            {
                return (bool)GetTemplateParameterValue("allowClientIp");
            }
            set
            {
                CreateTemplateParameterValue("allowClientIp", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Clientiprulename
        {
            get
            {
                return (string)GetTemplateParameterValue("clientIpRuleName");
            }
            set
            {
                CreateTemplateParameterValue("clientIpRuleName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Clientipvalue
        {
            get
            {
                return (string)GetTemplateParameterValue("clientIpValue");
            }
            set
            {
                CreateTemplateParameterValue("clientIpValue", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Requestedbackupstorageredundancy
        {
            get
            {
                return (string)GetTemplateParameterValue("requestedBackupStorageRedundancy");
            }
            set
            {
                CreateTemplateParameterValue("requestedBackupStorageRedundancy", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Maintenanceconfigurationid
        {
            get
            {
                return (string)GetTemplateParameterValue("maintenanceConfigurationId");
            }
            set
            {
                CreateTemplateParameterValue("maintenanceConfigurationId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Uri of the encryption key.")]
        public string Keyid
        {
            get
            {
                return (string)GetTemplateParameterValue("keyId");
            }
            set
            {
                CreateTemplateParameterValue("keyId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Azure Active Directory identity of the server.")]
        public object Identity
        {
            get
            {
                return (object)GetTemplateParameterValue("identity");
            }
            set
            {
                CreateTemplateParameterValue("identity", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "resource id of a user assigned identity to be used by default.")]
        public string Primaryuserassignedidentityid
        {
            get
            {
                return (string)GetTemplateParameterValue("primaryUserAssignedIdentityId");
            }
            set
            {
                CreateTemplateParameterValue("primaryUserAssignedIdentityId", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Minimaltlsversion
        {
            get
            {
                return (string)GetTemplateParameterValue("minimalTlsVersion");
            }
            set
            {
                CreateTemplateParameterValue("minimalTlsVersion", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Connectiontype
        {
            get
            {
                return (string)GetTemplateParameterValue("connectionType");
            }
            set
            {
                CreateTemplateParameterValue("connectionType", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Publicnetworkaccess
        {
            get
            {
                return (string)GetTemplateParameterValue("publicNetworkAccess");
            }
            set
            {
                CreateTemplateParameterValue("publicNetworkAccess", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Enablesqlledger
        {
            get
            {
                return (bool)GetTemplateParameterValue("enableSqlLedger");
            }
            set
            {
                CreateTemplateParameterValue("enableSqlLedger", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Enabledigeststorage
        {
            get
            {
                return (string)GetTemplateParameterValue("enableDigestStorage");
            }
            set
            {
                CreateTemplateParameterValue("enableDigestStorage", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Digeststorageoption
        {
            get
            {
                return (string)GetTemplateParameterValue("digestStorageOption");
            }
            set
            {
                CreateTemplateParameterValue("digestStorageOption", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Digeststoragename
        {
            get
            {
                return (string)GetTemplateParameterValue("digestStorageName");
            }
            set
            {
                CreateTemplateParameterValue("digestStorageName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Blobstoragecontainername
        {
            get
            {
                return (string)GetTemplateParameterValue("blobStorageContainerName");
            }
            set
            {
                CreateTemplateParameterValue("blobStorageContainerName", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Retentiondays
        {
            get
            {
                return (string)GetTemplateParameterValue("retentionDays");
            }
            set
            {
                CreateTemplateParameterValue("retentionDays", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Retentionpolicy
        {
            get
            {
                return (bool)GetTemplateParameterValue("retentionPolicy");
            }
            set
            {
                CreateTemplateParameterValue("retentionPolicy", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Digestaccountresourcegroup
        {
            get
            {
                return (string)GetTemplateParameterValue("digestAccountResourceGroup");
            }
            set
            {
                CreateTemplateParameterValue("digestAccountResourceGroup", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Digestregion
        {
            get
            {
                return (string)GetTemplateParameterValue("digestRegion");
            }
            set
            {
                CreateTemplateParameterValue("digestRegion", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Storageaccountdigestregion
        {
            get
            {
                return (string)GetTemplateParameterValue("storageAccountdigestRegion");
            }
            set
            {
                CreateTemplateParameterValue("storageAccountdigestRegion", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Isnewdigestlocation
        {
            get
            {
                return (bool)GetTemplateParameterValue("isNewDigestLocation");
            }
            set
            {
                CreateTemplateParameterValue("isNewDigestLocation", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public bool Ispermissionassigned
        {
            get
            {
                return (bool)GetTemplateParameterValue("isPermissionAssigned");
            }
            set
            {
                CreateTemplateParameterValue("isPermissionAssigned", value);
            }
        }


        [Parameter(ParameterSetName = "NewDatabaseNewServerNewElasticPool", Mandatory = false, HelpMessage = "Empty help message.")]
        public string Sqlledgertemplatelink
        {
            get
            {
                return (string)GetTemplateParameterValue("sqlLedgerTemplateLink");
            }
            set
            {
                CreateTemplateParameterValue("sqlLedgerTemplateLink", value);
            }
        }

    }
}
