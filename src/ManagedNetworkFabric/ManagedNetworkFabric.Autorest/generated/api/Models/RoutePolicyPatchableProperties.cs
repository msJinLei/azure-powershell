// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.Extensions;

    /// <summary>Route Policy patchable properties.</summary>
    public partial class RoutePolicyPatchableProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyPatchableProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyPatchablePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DefaultAction" /> property.</summary>
        private string _defaultAction;

        /// <summary>
        /// Default action that needs to be applied when no condition is matched. Example: Permit | Deny.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Origin(Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.PropertyOrigin.Owned)]
        public string DefaultAction { get => this._defaultAction; set => this._defaultAction = value; }

        /// <summary>Backing field for <see cref="Statement" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyStatementProperties> _statement;

        /// <summary>Route Policy statements.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Origin(Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyStatementProperties> Statement { get => this._statement; set => this._statement = value; }

        /// <summary>Creates an new <see cref="RoutePolicyPatchableProperties" /> instance.</summary>
        public RoutePolicyPatchableProperties()
        {

        }
    }
    /// Route Policy patchable properties.
    public partial interface IRoutePolicyPatchableProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Default action that needs to be applied when no condition is matched. Example: Permit | Deny.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Default action that needs to be applied when no condition is matched. Example: Permit | Deny.",
        SerializedName = @"defaultAction",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.PSArgumentCompleterAttribute("Permit", "Deny")]
        string DefaultAction { get; set; }
        /// <summary>Route Policy statements.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Route Policy statements.",
        SerializedName = @"statements",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyStatementProperties) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyStatementProperties> Statement { get; set; }

    }
    /// Route Policy patchable properties.
    internal partial interface IRoutePolicyPatchablePropertiesInternal

    {
        /// <summary>
        /// Default action that needs to be applied when no condition is matched. Example: Permit | Deny.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.PSArgumentCompleterAttribute("Permit", "Deny")]
        string DefaultAction { get; set; }
        /// <summary>Route Policy statements.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IRoutePolicyStatementProperties> Statement { get; set; }

    }
}