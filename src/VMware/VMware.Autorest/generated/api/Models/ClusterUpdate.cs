// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>An update of a cluster resource</summary>
    public partial class ClusterUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdateInternal
    {

        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public int? ClusterSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdatePropertiesInternal)Property).ClusterSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdatePropertiesInternal)Property).ClusterSize = value ?? default(int); }

        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> Host { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdatePropertiesInternal)Property).Host; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdatePropertiesInternal)Property).Host = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ClusterUpdateProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdateProperties _property;

        /// <summary>The properties of a cluster resource that may be updated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ClusterUpdateProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="ClusterUpdate" /> instance.</summary>
        public ClusterUpdate()
        {

        }
    }
    /// An update of a cluster resource
    public partial interface IClusterUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>The cluster size</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The cluster size",
        SerializedName = @"clusterSize",
        PossibleTypes = new [] { typeof(int) })]
        int? ClusterSize { get; set; }
        /// <summary>The hosts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The hosts",
        SerializedName = @"hosts",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Host { get; set; }

    }
    /// An update of a cluster resource
    internal partial interface IClusterUpdateInternal

    {
        /// <summary>The cluster size</summary>
        int? ClusterSize { get; set; }
        /// <summary>The hosts</summary>
        System.Collections.Generic.List<string> Host { get; set; }
        /// <summary>The properties of a cluster resource that may be updated</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IClusterUpdateProperties Property { get; set; }

    }
}