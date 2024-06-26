// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using System.Linq;

    /// <summary>
    /// Managed Identity used for CMK.
    /// </summary>
    public partial class CMKIdentityDefinition
    {
        /// <summary>
        /// Initializes a new instance of the CMKIdentityDefinition class.
        /// </summary>
        public CMKIdentityDefinition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CMKIdentityDefinition class.
        /// </summary>

        /// <param name="userAssignedIdentity">The resource id of the user assigned identity to authenticate to customer&#39;s
        /// key vault.
        /// </param>
        public CMKIdentityDefinition(string userAssignedIdentity = default(string))

        {
            this.UserAssignedIdentity = userAssignedIdentity;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the resource id of the user assigned identity to authenticate
        /// to customer&#39;s key vault.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "userAssignedIdentity")]
        public string UserAssignedIdentity {get; set; }
    }
}