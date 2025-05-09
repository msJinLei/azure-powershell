// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Network.Models
{
    using System.Linq;

    /// <summary>
    /// Service Endpoint policy definitions.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class ServiceEndpointPolicyDefinition : SubResource
    {
        /// <summary>
        /// Initializes a new instance of the ServiceEndpointPolicyDefinition class.
        /// </summary>
        public ServiceEndpointPolicyDefinition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ServiceEndpointPolicyDefinition class.
        /// </summary>

        /// <param name="id">Resource ID.
        /// </param>

        /// <param name="name">The name of the resource that is unique within a resource group. This name
        /// can be used to access the resource.
        /// </param>

        /// <param name="etag">A unique read-only string that changes whenever the resource is updated.
        /// </param>

        /// <param name="type">The type of the resource.
        /// </param>

        /// <param name="provisioningState">The provisioning state of the service endpoint policy definition resource.
        /// Possible values include: &#39;Failed&#39;, &#39;Succeeded&#39;, &#39;Canceled&#39;, &#39;Creating&#39;,
        /// &#39;Updating&#39;, &#39;Deleting&#39;</param>

        /// <param name="description">A description for this rule. Restricted to 140 chars.
        /// </param>

        /// <param name="service">Service endpoint name.
        /// </param>

        /// <param name="serviceResources">A list of service resources.
        /// </param>
        public ServiceEndpointPolicyDefinition(string id = default(string), string name = default(string), string etag = default(string), string type = default(string), string provisioningState = default(string), string description = default(string), string service = default(string), System.Collections.Generic.IList<string> serviceResources = default(System.Collections.Generic.IList<string>))

        : base(id)
        {
            this.Name = name;
            this.Etag = etag;
            this.Type = type;
            this.ProvisioningState = provisioningState;
            this.Description = description;
            this.Service = service;
            this.ServiceResources = serviceResources;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the name of the resource that is unique within a resource
        /// group. This name can be used to access the resource.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name {get; set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource is
        /// updated.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "etag")]
        public string Etag {get; private set; }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public string Type {get; set; }

        /// <summary>
        /// Gets the provisioning state of the service endpoint policy definition
        /// resource. Possible values include: &#39;Failed&#39;, &#39;Succeeded&#39;, &#39;Canceled&#39;, &#39;Creating&#39;, &#39;Updating&#39;, &#39;Deleting&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState {get; private set; }

        /// <summary>
        /// Gets or sets a description for this rule. Restricted to 140 chars.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.description")]
        public string Description {get; set; }

        /// <summary>
        /// Gets or sets service endpoint name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.service")]
        public string Service {get; set; }

        /// <summary>
        /// Gets or sets a list of service resources.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.serviceResources")]
        public System.Collections.Generic.IList<string> ServiceResources {get; set; }
    }
}