
using System.Collections;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sql.Resources.Extensions
{
    public class PSResourceProviderResourceType
    {
        /// <summary>
        /// Gets or sets the name of the resource type.
        /// </summary>
        public string ResourceTypeName { get; set; }

        /// <summary>
        /// Gets or sets the locations this resource is available in.
        /// </summary>
        public string[] Locations { get; set; }

        /// <summary>
        /// Gets or sets the api versions that this resource is supported in.
        /// </summary>
        public string[] ApiVersions { get; set; }

        /// <summary>
        /// Gets or sets the zone mappings that this resource supports.
        /// </summary>
        public Hashtable ZoneMappings { get; set; }
    }
}