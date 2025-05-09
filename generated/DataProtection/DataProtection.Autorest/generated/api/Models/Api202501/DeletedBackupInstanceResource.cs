// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Deleted Backup Instance</summary>
    public partial class DeletedBackupInstanceResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceResource,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResource __dppResource = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.DppResource();

        /// <summary>Specifies the current protection state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? CurrentProtectionState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).CurrentProtectionState; }

        /// <summary>Gets or sets the data source information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDatasource DataSourceInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).DataSourceInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).DataSourceInfo = value ?? null /* model class */; }

        /// <summary>Gets or sets the data source set information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDatasourceSet DataSourceSetInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).DataSourceSetInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).DataSourceSetInfo = value ?? null /* model class */; }

        /// <summary>Credentials to use to authenticate with data source provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IAuthCredentials DatasourceAuthCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).DatasourceAuthCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).DatasourceAuthCredentials = value ?? null /* model class */; }

        /// <summary>Deletion info of Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletionInfo DeletionInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceInternal)Property).DeletionInfo; }

        /// <summary>Gets or sets the Backup Instance friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).FriendlyName = value ?? null; }

        /// <summary>Resource Id represents the complete path to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Id; }

        /// <summary>
        /// Contains information of the Identity Details for the BI.
        /// If it is null, default will be considered as System Assigned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IIdentityDetails IdentityDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).IdentityDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).IdentityDetail = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CurrentProtectionState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceResourceInternal.CurrentProtectionState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).CurrentProtectionState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).CurrentProtectionState = value; }

        /// <summary>Internal Acessors for DeletionInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletionInfo Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceResourceInternal.DeletionInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceInternal)Property).DeletionInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceInternal)Property).DeletionInfo = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstance Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.DeletedBackupInstance()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProtectionErrorDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IUserFacingError Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceResourceInternal.ProtectionErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProtectionErrorDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProtectionErrorDetail = value; }

        /// <summary>Internal Acessors for ProtectionStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IProtectionStatusDetails Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceResourceInternal.ProtectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProtectionStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProtectionStatus = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstanceResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api40.ISystemData Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Type = value; }

        /// <summary>Resource name associated with the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Name; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ObjectType = value ?? null; }

        /// <summary>Gets or sets the policy information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IPolicyInfo PolicyInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).PolicyInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).PolicyInfo = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstance _property;

        /// <summary>DeletedBackupInstanceResource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstance Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.DeletedBackupInstance()); set => this._property = value; }

        /// <summary>Specifies the protection error of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IUserFacingError ProtectionErrorDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProtectionErrorDetail; }

        /// <summary>Specifies the protection status of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IProtectionStatusDetails ProtectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProtectionStatus; }

        /// <summary>
        /// Specifies the provisioning state of the resource i.e. provisioning/updating/Succeeded/Failed
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ProvisioningState; }

        /// <summary>ResourceGuardOperationRequests on which LAC check will be performed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string[] ResourceGuardOperationRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ResourceGuardOperationRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ResourceGuardOperationRequest = value ?? null /* arrayOf */; }

        /// <summary>Metadata pertaining to creation and last modification of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api40.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).SystemData; }

        /// <summary>
        /// Resource type represents the complete path of the form Namespace/ResourceType/ResourceType/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal)__dppResource).Type; }

        /// <summary>
        /// Specifies the type of validation. In case of DeepValidation, all validations from /validateForBackup API will run again.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ValidationType? ValidationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ValidationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IBackupInstanceInternal)Property).ValidationType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ValidationType)""); }

        /// <summary>Creates an new <see cref="DeletedBackupInstanceResource" /> instance.</summary>
        public DeletedBackupInstanceResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__dppResource), __dppResource);
            await eventListener.AssertObjectIsValid(nameof(__dppResource), __dppResource);
        }
    }
    /// Deleted Backup Instance
    public partial interface IDeletedBackupInstanceResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResource
    {
        /// <summary>Specifies the current protection state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the current protection state of the resource",
        SerializedName = @"currentProtectionState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? CurrentProtectionState { get;  }
        /// <summary>Gets or sets the data source information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the data source information.",
        SerializedName = @"dataSourceInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDatasource) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDatasource DataSourceInfo { get; set; }
        /// <summary>Gets or sets the data source set information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the data source set information.",
        SerializedName = @"dataSourceSetInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDatasourceSet) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDatasourceSet DataSourceSetInfo { get; set; }
        /// <summary>Credentials to use to authenticate with data source provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Credentials to use to authenticate with data source provider.",
        SerializedName = @"datasourceAuthCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IAuthCredentials) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IAuthCredentials DatasourceAuthCredentials { get; set; }
        /// <summary>Deletion info of Backup Instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Deletion info of Backup Instance",
        SerializedName = @"deletionInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletionInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletionInfo DeletionInfo { get;  }
        /// <summary>Gets or sets the Backup Instance friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the Backup Instance friendly name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>
        /// Contains information of the Identity Details for the BI.
        /// If it is null, default will be considered as System Assigned.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Contains information of the Identity Details for the BI.
        If it is null, default will be considered as System Assigned.",
        SerializedName = @"identityDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IIdentityDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IIdentityDetails IdentityDetail { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>Gets or sets the policy information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the policy information.",
        SerializedName = @"policyInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IPolicyInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IPolicyInfo PolicyInfo { get; set; }
        /// <summary>Specifies the protection error of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the protection error of the resource",
        SerializedName = @"protectionErrorDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IUserFacingError) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IUserFacingError ProtectionErrorDetail { get;  }
        /// <summary>Specifies the protection status of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the protection status of the resource",
        SerializedName = @"protectionStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IProtectionStatusDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IProtectionStatusDetails ProtectionStatus { get;  }
        /// <summary>
        /// Specifies the provisioning state of the resource i.e. provisioning/updating/Succeeded/Failed
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the provisioning state of the resource i.e. provisioning/updating/Succeeded/Failed",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>ResourceGuardOperationRequests on which LAC check will be performed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ResourceGuardOperationRequests on which LAC check will be performed",
        SerializedName = @"resourceGuardOperationRequests",
        PossibleTypes = new [] { typeof(string) })]
        string[] ResourceGuardOperationRequest { get; set; }
        /// <summary>
        /// Specifies the type of validation. In case of DeepValidation, all validations from /validateForBackup API will run again.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the type of validation. In case of DeepValidation, all validations from /validateForBackup API will run again.",
        SerializedName = @"validationType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ValidationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ValidationType? ValidationType { get; set; }

    }
    /// Deleted Backup Instance
    internal partial interface IDeletedBackupInstanceResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDppResourceInternal
    {
        /// <summary>Specifies the current protection state of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CurrentProtectionState? CurrentProtectionState { get; set; }
        /// <summary>Gets or sets the data source information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDatasource DataSourceInfo { get; set; }
        /// <summary>Gets or sets the data source set information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDatasourceSet DataSourceSetInfo { get; set; }
        /// <summary>Credentials to use to authenticate with data source provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IAuthCredentials DatasourceAuthCredentials { get; set; }
        /// <summary>Deletion info of Backup Instance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletionInfo DeletionInfo { get; set; }
        /// <summary>Gets or sets the Backup Instance friendly name.</summary>
        string FriendlyName { get; set; }
        /// <summary>
        /// Contains information of the Identity Details for the BI.
        /// If it is null, default will be considered as System Assigned.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IIdentityDetails IdentityDetail { get; set; }

        string ObjectType { get; set; }
        /// <summary>Gets or sets the policy information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IPolicyInfo PolicyInfo { get; set; }
        /// <summary>DeletedBackupInstanceResource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IDeletedBackupInstance Property { get; set; }
        /// <summary>Specifies the protection error of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IUserFacingError ProtectionErrorDetail { get; set; }
        /// <summary>Specifies the protection status of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202501.IProtectionStatusDetails ProtectionStatus { get; set; }
        /// <summary>
        /// Specifies the provisioning state of the resource i.e. provisioning/updating/Succeeded/Failed
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>ResourceGuardOperationRequests on which LAC check will be performed</summary>
        string[] ResourceGuardOperationRequest { get; set; }
        /// <summary>
        /// Specifies the type of validation. In case of DeepValidation, all validations from /validateForBackup API will run again.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ValidationType? ValidationType { get; set; }

    }
}