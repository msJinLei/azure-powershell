// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Storage.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Extensions;

    /// <summary>A name-value pair to associate with the share as metadata.</summary>
    public partial class FileSharePropertiesMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileSharePropertiesMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileSharePropertiesMetadataInternal
    {

        /// <summary>Creates an new <see cref="FileSharePropertiesMetadata" /> instance.</summary>
        public FileSharePropertiesMetadata()
        {

        }
    }
    /// A name-value pair to associate with the share as metadata.
    public partial interface IFileSharePropertiesMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IAssociativeArray<string>
    {

    }
    /// A name-value pair to associate with the share as metadata.
    internal partial interface IFileSharePropertiesMetadataInternal

    {

    }
}