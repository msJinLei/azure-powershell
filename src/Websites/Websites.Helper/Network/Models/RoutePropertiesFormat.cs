// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Helper.Network.Models
{
    using System.Linq;

    /// <summary>
    /// Route resource.
    /// </summary>
    public partial class RoutePropertiesFormat
    {
        /// <summary>
        /// Initializes a new instance of the RoutePropertiesFormat class.
        /// </summary>
        public RoutePropertiesFormat()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RoutePropertiesFormat class.
        /// </summary>

        /// <param name="addressPrefix">The destination CIDR to which the route applies.
        /// </param>

        /// <param name="nextHopType">The type of Azure hop the packet should be sent to.
        /// Possible values include: &#39;VirtualNetworkGateway&#39;, &#39;VnetLocal&#39;, &#39;Internet&#39;,
        /// &#39;VirtualAppliance&#39;, &#39;None&#39;</param>

        /// <param name="nextHopIPAddress">The IP address packets should be forwarded to. Next hop values are only
        /// allowed in routes where the next hop type is VirtualAppliance.
        /// </param>

        /// <param name="provisioningState">The provisioning state of the route resource.
        /// Possible values include: &#39;Succeeded&#39;, &#39;Updating&#39;, &#39;Deleting&#39;, &#39;Failed&#39;</param>
        public RoutePropertiesFormat(string nextHopType, string addressPrefix = default(string), string nextHopIPAddress = default(string), string provisioningState = default(string))

        {
            this.AddressPrefix = addressPrefix;
            this.NextHopType = nextHopType;
            this.NextHopIPAddress = nextHopIPAddress;
            this.ProvisioningState = provisioningState;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the destination CIDR to which the route applies.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "addressPrefix")]
        public string AddressPrefix {get; set; }

        /// <summary>
        /// Gets or sets the type of Azure hop the packet should be sent to. Possible values include: &#39;VirtualNetworkGateway&#39;, &#39;VnetLocal&#39;, &#39;Internet&#39;, &#39;VirtualAppliance&#39;, &#39;None&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "nextHopType")]
        public string NextHopType {get; set; }

        /// <summary>
        /// Gets or sets the IP address packets should be forwarded to. Next hop values
        /// are only allowed in routes where the next hop type is VirtualAppliance.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "nextHopIpAddress")]
        public string NextHopIPAddress {get; set; }

        /// <summary>
        /// Gets the provisioning state of the route resource. Possible values include: &#39;Succeeded&#39;, &#39;Updating&#39;, &#39;Deleting&#39;, &#39;Failed&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState {get; private set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.NextHopType == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "NextHopType");
            }




        }
    }
}