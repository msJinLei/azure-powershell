// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.Extensions;

    /// <summary>Localizable String object containing the name and a localized value.</summary>
    public partial class SignalRServiceUsageName :
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.ISignalRServiceUsageName,
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.ISignalRServiceUsageNameInternal
    {

        /// <summary>Backing field for <see cref="LocalizedValue" /> property.</summary>
        private string _localizedValue;

        /// <summary>Localized name of the usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Origin(Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.PropertyOrigin.Owned)]
        public string LocalizedValue { get => this._localizedValue; set => this._localizedValue = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>The identifier of the usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Origin(Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="SignalRServiceUsageName" /> instance.</summary>
        public SignalRServiceUsageName()
        {

        }
    }
    /// Localizable String object containing the name and a localized value.
    public partial interface ISignalRServiceUsageName :
        Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.IJsonSerializable
    {
        /// <summary>Localized name of the usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized name of the usage.",
        SerializedName = @"localizedValue",
        PossibleTypes = new [] { typeof(string) })]
        string LocalizedValue { get; set; }
        /// <summary>The identifier of the usage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identifier of the usage.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Localizable String object containing the name and a localized value.
    internal partial interface ISignalRServiceUsageNameInternal

    {
        /// <summary>Localized name of the usage.</summary>
        string LocalizedValue { get; set; }
        /// <summary>The identifier of the usage.</summary>
        string Value { get; set; }

    }
}