// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.Extensions;

    /// <summary>The Prometheus rule group resource.</summary>
    public partial class PrometheusRuleGroupResource :
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupResource,
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.TrackedResource();

        /// <summary>Apply rule to data from a specific cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.FormatTable(Index = 2)]
        public string ClusterName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).ClusterName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).ClusterName = value ?? null; }

        /// <summary>Rule group description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>Enable/disable rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.FormatTable(Index = 3)]
        public bool? Enabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Enabled = value ?? default(bool); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Id; }

        /// <summary>
        /// The interval in which to run the Prometheus rule group represented in ISO 8601 duration format. Should be between 1 and
        /// 15 minutes
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public global::System.TimeSpan? Interval { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Interval; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Interval = value ?? default(global::System.TimeSpan); }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResourceInternal)__trackedResource).Location = value ; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupProperties Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.PrometheusRuleGroupProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ISystemData Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupProperties _property;

        /// <summary>The Prometheus rule group properties of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.PrometheusRuleGroupProperties()); set => this._property = value; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>Defines the rules in the Prometheus rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRule> Rule { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Rule; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Rule = value ; }

        /// <summary>
        /// Target Azure Monitor workspaces resource ids. This api-version is currently limited to creating with one scope. This may
        /// change in future.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public System.Collections.Generic.List<string> Scope { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Scope; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupPropertiesInternal)Property).Scope = value ; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemData; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataCreatedBy = value ?? null; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public string SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataCreatedByType = value ?? null; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public string SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value ?? null; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Origin(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="PrometheusRuleGroupResource" /> instance.</summary>
        public PrometheusRuleGroupResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// The Prometheus rule group resource.
    public partial interface IPrometheusRuleGroupResource :
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResource
    {
        /// <summary>Apply rule to data from a specific cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Apply rule to data from a specific cluster.",
        SerializedName = @"clusterName",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterName { get; set; }
        /// <summary>Rule group description.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Rule group description.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Enable/disable rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Enable/disable rule group.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>
        /// The interval in which to run the Prometheus rule group represented in ISO 8601 duration format. Should be between 1 and
        /// 15 minutes
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The interval in which to run the Prometheus rule group represented in ISO 8601 duration format. Should be between 1 and 15 minutes",
        SerializedName = @"interval",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? Interval { get; set; }
        /// <summary>Defines the rules in the Prometheus rule group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Defines the rules in the Prometheus rule group.",
        SerializedName = @"rules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRule) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRule> Rule { get; set; }
        /// <summary>
        /// Target Azure Monitor workspaces resource ids. This api-version is currently limited to creating with one scope. This may
        /// change in future.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Target Azure Monitor workspaces resource ids. This api-version is currently limited to creating with one scope. This may change in future.",
        SerializedName = @"scopes",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Scope { get; set; }

    }
    /// The Prometheus rule group resource.
    internal partial interface IPrometheusRuleGroupResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.ITrackedResourceInternal
    {
        /// <summary>Apply rule to data from a specific cluster.</summary>
        string ClusterName { get; set; }
        /// <summary>Rule group description.</summary>
        string Description { get; set; }
        /// <summary>Enable/disable rule group.</summary>
        bool? Enabled { get; set; }
        /// <summary>
        /// The interval in which to run the Prometheus rule group represented in ISO 8601 duration format. Should be between 1 and
        /// 15 minutes
        /// </summary>
        global::System.TimeSpan? Interval { get; set; }
        /// <summary>The Prometheus rule group properties of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRuleGroupProperties Property { get; set; }
        /// <summary>Defines the rules in the Prometheus rule group.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PrometheusRuleGroups.Models.IPrometheusRule> Rule { get; set; }
        /// <summary>
        /// Target Azure Monitor workspaces resource ids. This api-version is currently limited to creating with one scope. This may
        /// change in future.
        /// </summary>
        System.Collections.Generic.List<string> Scope { get; set; }

    }
}