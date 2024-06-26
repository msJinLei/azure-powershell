// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Storage.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Extensions;

    /// <summary>Settings properties for Active Directory (AD).</summary>
    public partial class ActiveDirectoryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IActiveDirectoryProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IActiveDirectoryPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AccountType" /> property.</summary>
        private string _accountType;

        /// <summary>Specifies the Active Directory account type for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string AccountType { get => this._accountType; set => this._accountType = value; }

        /// <summary>Backing field for <see cref="AzureStorageSid" /> property.</summary>
        private string _azureStorageSid;

        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string AzureStorageSid { get => this._azureStorageSid; set => this._azureStorageSid = value; }

        /// <summary>Backing field for <see cref="DomainGuid" /> property.</summary>
        private string _domainGuid;

        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string DomainGuid { get => this._domainGuid; set => this._domainGuid = value; }

        /// <summary>Backing field for <see cref="DomainName" /> property.</summary>
        private string _domainName;

        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string DomainName { get => this._domainName; set => this._domainName = value; }

        /// <summary>Backing field for <see cref="DomainSid" /> property.</summary>
        private string _domainSid;

        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string DomainSid { get => this._domainSid; set => this._domainSid = value; }

        /// <summary>Backing field for <see cref="ForestName" /> property.</summary>
        private string _forestName;

        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string ForestName { get => this._forestName; set => this._forestName = value; }

        /// <summary>Backing field for <see cref="NetBiosDomainName" /> property.</summary>
        private string _netBiosDomainName;

        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string NetBiosDomainName { get => this._netBiosDomainName; set => this._netBiosDomainName = value; }

        /// <summary>Backing field for <see cref="SamAccountName" /> property.</summary>
        private string _samAccountName;

        /// <summary>Specifies the Active Directory SAMAccountName for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string SamAccountName { get => this._samAccountName; set => this._samAccountName = value; }

        /// <summary>Creates an new <see cref="ActiveDirectoryProperties" /> instance.</summary>
        public ActiveDirectoryProperties()
        {

        }
    }
    /// Settings properties for Active Directory (AD).
    public partial interface IActiveDirectoryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IJsonSerializable
    {
        /// <summary>Specifies the Active Directory account type for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the Active Directory account type for Azure Storage.",
        SerializedName = @"accountType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("User", "Computer")]
        string AccountType { get; set; }
        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the security identifier (SID) for Azure Storage.",
        SerializedName = @"azureStorageSid",
        PossibleTypes = new [] { typeof(string) })]
        string AzureStorageSid { get; set; }
        /// <summary>Specifies the domain GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the domain GUID.",
        SerializedName = @"domainGuid",
        PossibleTypes = new [] { typeof(string) })]
        string DomainGuid { get; set; }
        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the primary domain that the AD DNS server is authoritative for.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string DomainName { get; set; }
        /// <summary>Specifies the security identifier (SID).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the security identifier (SID).",
        SerializedName = @"domainSid",
        PossibleTypes = new [] { typeof(string) })]
        string DomainSid { get; set; }
        /// <summary>Specifies the Active Directory forest to get.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the Active Directory forest to get.",
        SerializedName = @"forestName",
        PossibleTypes = new [] { typeof(string) })]
        string ForestName { get; set; }
        /// <summary>Specifies the NetBIOS domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the NetBIOS domain name.",
        SerializedName = @"netBiosDomainName",
        PossibleTypes = new [] { typeof(string) })]
        string NetBiosDomainName { get; set; }
        /// <summary>Specifies the Active Directory SAMAccountName for Azure Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Specifies the Active Directory SAMAccountName for Azure Storage.",
        SerializedName = @"samAccountName",
        PossibleTypes = new [] { typeof(string) })]
        string SamAccountName { get; set; }

    }
    /// Settings properties for Active Directory (AD).
    internal partial interface IActiveDirectoryPropertiesInternal

    {
        /// <summary>Specifies the Active Directory account type for Azure Storage.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("User", "Computer")]
        string AccountType { get; set; }
        /// <summary>Specifies the security identifier (SID) for Azure Storage.</summary>
        string AzureStorageSid { get; set; }
        /// <summary>Specifies the domain GUID.</summary>
        string DomainGuid { get; set; }
        /// <summary>Specifies the primary domain that the AD DNS server is authoritative for.</summary>
        string DomainName { get; set; }
        /// <summary>Specifies the security identifier (SID).</summary>
        string DomainSid { get; set; }
        /// <summary>Specifies the Active Directory forest to get.</summary>
        string ForestName { get; set; }
        /// <summary>Specifies the NetBIOS domain name.</summary>
        string NetBiosDomainName { get; set; }
        /// <summary>Specifies the Active Directory SAMAccountName for Azure Storage.</summary>
        string SamAccountName { get; set; }

    }
}