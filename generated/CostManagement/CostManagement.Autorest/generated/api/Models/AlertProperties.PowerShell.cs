// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>Alert properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(AlertPropertiesTypeConverter))]
    public partial class AlertProperties
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AlertProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AlertProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Definition"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AlertPropertiesDefinitionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Detail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesDetails) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Detail, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AlertPropertiesDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("Source"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Source = (string) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Source, global::System.Convert.ToString);
            }
            if (content.Contains("CostEntityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CostEntityId = (string) content.GetValueForProperty("CostEntityId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CostEntityId, global::System.Convert.ToString);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Status, global::System.Convert.ToString);
            }
            if (content.Contains("CreationTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CreationTime = (string) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CreationTime, global::System.Convert.ToString);
            }
            if (content.Contains("CloseTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CloseTime = (string) content.GetValueForProperty("CloseTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CloseTime, global::System.Convert.ToString);
            }
            if (content.Contains("ModificationTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).ModificationTime = (string) content.GetValueForProperty("ModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).ModificationTime, global::System.Convert.ToString);
            }
            if (content.Contains("StatusModificationUserName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).StatusModificationUserName = (string) content.GetValueForProperty("StatusModificationUserName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).StatusModificationUserName, global::System.Convert.ToString);
            }
            if (content.Contains("StatusModificationTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).StatusModificationTime = (string) content.GetValueForProperty("StatusModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).StatusModificationTime, global::System.Convert.ToString);
            }
            if (content.Contains("DefinitionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionType = (string) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionType, global::System.Convert.ToString);
            }
            if (content.Contains("DefinitionCategory"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionCategory = (string) content.GetValueForProperty("DefinitionCategory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionCategory, global::System.Convert.ToString);
            }
            if (content.Contains("DefinitionCriterion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionCriterion = (string) content.GetValueForProperty("DefinitionCriterion",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionCriterion, global::System.Convert.ToString);
            }
            if (content.Contains("DetailTimeGrainType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTimeGrainType = (string) content.GetValueForProperty("DetailTimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTimeGrainType, global::System.Convert.ToString);
            }
            if (content.Contains("DetailPeriodStartDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailPeriodStartDate = (string) content.GetValueForProperty("DetailPeriodStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailPeriodStartDate, global::System.Convert.ToString);
            }
            if (content.Contains("DetailTriggeredBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTriggeredBy = (string) content.GetValueForProperty("DetailTriggeredBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTriggeredBy, global::System.Convert.ToString);
            }
            if (content.Contains("DetailResourceGroupFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailResourceGroupFilter = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailResourceGroupFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailResourceGroupFilter, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailResourceFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailResourceFilter = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailResourceFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailResourceFilter, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailMeterFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailMeterFilter = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailMeterFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailMeterFilter, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailTagFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTagFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) content.GetValueForProperty("DetailTagFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTagFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("DetailThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailThreshold = (decimal?) content.GetValueForProperty("DetailThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailThreshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            }
            if (content.Contains("DetailOperator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailOperator = (string) content.GetValueForProperty("DetailOperator",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailOperator, global::System.Convert.ToString);
            }
            if (content.Contains("DetailAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailAmount = (decimal?) content.GetValueForProperty("DetailAmount",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailAmount, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            }
            if (content.Contains("DetailUnit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailUnit = (string) content.GetValueForProperty("DetailUnit",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailUnit, global::System.Convert.ToString);
            }
            if (content.Contains("DetailCurrentSpend"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailCurrentSpend = (decimal?) content.GetValueForProperty("DetailCurrentSpend",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailCurrentSpend, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            }
            if (content.Contains("DetailContactEmail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactEmail = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactEmail, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailContactGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactGroup = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailContactGroup",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactGroup, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailContactRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactRole = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailContactRole",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactRole, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailOverridingAlert"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailOverridingAlert = (string) content.GetValueForProperty("DetailOverridingAlert",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailOverridingAlert, global::System.Convert.ToString);
            }
            if (content.Contains("DetailDepartmentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailDepartmentName = (string) content.GetValueForProperty("DetailDepartmentName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailDepartmentName, global::System.Convert.ToString);
            }
            if (content.Contains("DetailCompanyName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailCompanyName = (string) content.GetValueForProperty("DetailCompanyName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailCompanyName, global::System.Convert.ToString);
            }
            if (content.Contains("DetailEnrollmentNumber"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentNumber = (string) content.GetValueForProperty("DetailEnrollmentNumber",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentNumber, global::System.Convert.ToString);
            }
            if (content.Contains("DetailEnrollmentStartDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentStartDate = (string) content.GetValueForProperty("DetailEnrollmentStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentStartDate, global::System.Convert.ToString);
            }
            if (content.Contains("DetailEnrollmentEndDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentEndDate = (string) content.GetValueForProperty("DetailEnrollmentEndDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentEndDate, global::System.Convert.ToString);
            }
            if (content.Contains("DetailInvoicingThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailInvoicingThreshold = (decimal?) content.GetValueForProperty("DetailInvoicingThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailInvoicingThreshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AlertProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AlertProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Definition"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AlertPropertiesDefinitionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Detail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesDetails) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Detail, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AlertPropertiesDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("Source"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Source = (string) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Source, global::System.Convert.ToString);
            }
            if (content.Contains("CostEntityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CostEntityId = (string) content.GetValueForProperty("CostEntityId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CostEntityId, global::System.Convert.ToString);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).Status, global::System.Convert.ToString);
            }
            if (content.Contains("CreationTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CreationTime = (string) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CreationTime, global::System.Convert.ToString);
            }
            if (content.Contains("CloseTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CloseTime = (string) content.GetValueForProperty("CloseTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).CloseTime, global::System.Convert.ToString);
            }
            if (content.Contains("ModificationTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).ModificationTime = (string) content.GetValueForProperty("ModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).ModificationTime, global::System.Convert.ToString);
            }
            if (content.Contains("StatusModificationUserName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).StatusModificationUserName = (string) content.GetValueForProperty("StatusModificationUserName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).StatusModificationUserName, global::System.Convert.ToString);
            }
            if (content.Contains("StatusModificationTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).StatusModificationTime = (string) content.GetValueForProperty("StatusModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).StatusModificationTime, global::System.Convert.ToString);
            }
            if (content.Contains("DefinitionType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionType = (string) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionType, global::System.Convert.ToString);
            }
            if (content.Contains("DefinitionCategory"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionCategory = (string) content.GetValueForProperty("DefinitionCategory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionCategory, global::System.Convert.ToString);
            }
            if (content.Contains("DefinitionCriterion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionCriterion = (string) content.GetValueForProperty("DefinitionCriterion",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DefinitionCriterion, global::System.Convert.ToString);
            }
            if (content.Contains("DetailTimeGrainType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTimeGrainType = (string) content.GetValueForProperty("DetailTimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTimeGrainType, global::System.Convert.ToString);
            }
            if (content.Contains("DetailPeriodStartDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailPeriodStartDate = (string) content.GetValueForProperty("DetailPeriodStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailPeriodStartDate, global::System.Convert.ToString);
            }
            if (content.Contains("DetailTriggeredBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTriggeredBy = (string) content.GetValueForProperty("DetailTriggeredBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTriggeredBy, global::System.Convert.ToString);
            }
            if (content.Contains("DetailResourceGroupFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailResourceGroupFilter = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailResourceGroupFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailResourceGroupFilter, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailResourceFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailResourceFilter = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailResourceFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailResourceFilter, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailMeterFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailMeterFilter = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailMeterFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailMeterFilter, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailTagFilter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTagFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) content.GetValueForProperty("DetailTagFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailTagFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("DetailThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailThreshold = (decimal?) content.GetValueForProperty("DetailThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailThreshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            }
            if (content.Contains("DetailOperator"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailOperator = (string) content.GetValueForProperty("DetailOperator",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailOperator, global::System.Convert.ToString);
            }
            if (content.Contains("DetailAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailAmount = (decimal?) content.GetValueForProperty("DetailAmount",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailAmount, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            }
            if (content.Contains("DetailUnit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailUnit = (string) content.GetValueForProperty("DetailUnit",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailUnit, global::System.Convert.ToString);
            }
            if (content.Contains("DetailCurrentSpend"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailCurrentSpend = (decimal?) content.GetValueForProperty("DetailCurrentSpend",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailCurrentSpend, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            }
            if (content.Contains("DetailContactEmail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactEmail = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactEmail, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailContactGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactGroup = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailContactGroup",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactGroup, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailContactRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactRole = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailContactRole",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailContactRole, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailOverridingAlert"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailOverridingAlert = (string) content.GetValueForProperty("DetailOverridingAlert",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailOverridingAlert, global::System.Convert.ToString);
            }
            if (content.Contains("DetailDepartmentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailDepartmentName = (string) content.GetValueForProperty("DetailDepartmentName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailDepartmentName, global::System.Convert.ToString);
            }
            if (content.Contains("DetailCompanyName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailCompanyName = (string) content.GetValueForProperty("DetailCompanyName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailCompanyName, global::System.Convert.ToString);
            }
            if (content.Contains("DetailEnrollmentNumber"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentNumber = (string) content.GetValueForProperty("DetailEnrollmentNumber",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentNumber, global::System.Convert.ToString);
            }
            if (content.Contains("DetailEnrollmentStartDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentStartDate = (string) content.GetValueForProperty("DetailEnrollmentStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentStartDate, global::System.Convert.ToString);
            }
            if (content.Contains("DetailEnrollmentEndDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentEndDate = (string) content.GetValueForProperty("DetailEnrollmentEndDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailEnrollmentEndDate, global::System.Convert.ToString);
            }
            if (content.Contains("DetailInvoicingThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailInvoicingThreshold = (decimal?) content.GetValueForProperty("DetailInvoicingThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertPropertiesInternal)this).DetailInvoicingThreshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AlertProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AlertProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AlertProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AlertProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AlertProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="AlertProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAlertProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Alert properties.
    [System.ComponentModel.TypeConverter(typeof(AlertPropertiesTypeConverter))]
    public partial interface IAlertProperties

    {

    }
}