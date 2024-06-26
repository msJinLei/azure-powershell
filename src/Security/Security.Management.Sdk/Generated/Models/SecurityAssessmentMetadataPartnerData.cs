// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Security.Models
{
    using System.Linq;

    /// <summary>
    /// Describes the partner that created the assessment
    /// </summary>
    public partial class SecurityAssessmentMetadataPartnerData
    {
        /// <summary>
        /// Initializes a new instance of the SecurityAssessmentMetadataPartnerData class.
        /// </summary>
        public SecurityAssessmentMetadataPartnerData()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SecurityAssessmentMetadataPartnerData class.
        /// </summary>

        /// <param name="partnerName">Name of the company of the partner
        /// </param>

        /// <param name="productName">Name of the product of the partner that created the assessment
        /// </param>

        /// <param name="secret">Secret to authenticate the partner and verify it created the assessment -
        /// write only
        /// </param>
        public SecurityAssessmentMetadataPartnerData(string partnerName, string secret, string productName = default(string))

        {
            this.PartnerName = partnerName;
            this.ProductName = productName;
            this.Secret = secret;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets name of the company of the partner
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "partnerName")]
        public string PartnerName {get; set; }

        /// <summary>
        /// Gets or sets name of the product of the partner that created the assessment
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "productName")]
        public string ProductName {get; set; }

        /// <summary>
        /// Gets or sets secret to authenticate the partner and verify it created the
        /// assessment - write only
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "secret")]
        public string Secret {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.PartnerName == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "PartnerName");
            }
            if (this.Secret == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Secret");
            }



        }
    }
}