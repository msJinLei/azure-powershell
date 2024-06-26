// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Extensions;

    /// <summary>Gets or sets the Resource tags.</summary>
    public partial class VirtualMachineTemplateTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IVirtualMachineTemplateTags,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IVirtualMachineTemplateTagsInternal
    {

        /// <summary>Creates an new <see cref="VirtualMachineTemplateTags" /> instance.</summary>
        public VirtualMachineTemplateTags()
        {

        }
    }
    /// Gets or sets the Resource tags.
    public partial interface IVirtualMachineTemplateTags :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.IAssociativeArray<string>
    {

    }
    /// Gets or sets the Resource tags.
    internal partial interface IVirtualMachineTemplateTagsInternal

    {

    }
}