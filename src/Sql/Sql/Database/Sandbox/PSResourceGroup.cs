using System.Collections;

namespace Microsoft.Azure.Commands.Sql.Database.Sandbox
{
    public class PSResourceGroup
    {
        public string ResourceGroupName { get; set; }

        public string Location { get; set; }

        public string ProvisioningState { get; set; }

        public Hashtable Tags { get; set; }

        public string TagsTable
        {
            get { return ResourcesExtensions.ConstructTagsTable(Tags); }
        }

        public string ResourceId { get; set; }

        public string ManagedBy { get; set; }
    }
}