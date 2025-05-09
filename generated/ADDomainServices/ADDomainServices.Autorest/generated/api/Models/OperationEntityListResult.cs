// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>The list of domain service operation response.</summary>
    public partial class OperationEntityListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IOperationEntityListResult,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IOperationEntityListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IOperationEntityListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The continuation token for the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IOperationEntity> _value;

        /// <summary>The list of operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IOperationEntity> Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationEntityListResult" /> instance.</summary>
        public OperationEntityListResult()
        {

        }
    }
    /// The list of domain service operation response.
    public partial interface IOperationEntityListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>The continuation token for the next page of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The continuation token for the next page of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>The list of operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of operations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IOperationEntity) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IOperationEntity> Value { get; set; }

    }
    /// The list of domain service operation response.
    internal partial interface IOperationEntityListResultInternal

    {
        /// <summary>The continuation token for the next page of results.</summary>
        string NextLink { get; set; }
        /// <summary>The list of operations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IOperationEntity> Value { get; set; }

    }
}