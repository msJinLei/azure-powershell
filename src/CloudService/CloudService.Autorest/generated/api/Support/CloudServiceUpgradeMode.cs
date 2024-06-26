// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support
{

    /// <summary>
    /// Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates
    /// can be initiated manually in each update domain or initiated automatically in all update domains.
    /// Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />
    /// If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If
    /// set to Auto, the update is automatically applied to each update domain in sequence.
    /// </summary>
    public partial struct CloudServiceUpgradeMode :
        System.IEquatable<CloudServiceUpgradeMode>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode Auto = @"Auto";

        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode Manual = @"Manual";

        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode Simultaneous = @"Simultaneous";

        /// <summary>the value for an instance of the <see cref="CloudServiceUpgradeMode" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="CloudServiceUpgradeMode"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private CloudServiceUpgradeMode(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to CloudServiceUpgradeMode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="CloudServiceUpgradeMode" />.</param>
        internal static object CreateFrom(object value)
        {
            return new CloudServiceUpgradeMode(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type CloudServiceUpgradeMode</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type CloudServiceUpgradeMode (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is CloudServiceUpgradeMode && Equals((CloudServiceUpgradeMode)obj);
        }

        /// <summary>Returns hashCode for enum CloudServiceUpgradeMode</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for CloudServiceUpgradeMode</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to CloudServiceUpgradeMode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="CloudServiceUpgradeMode" />.</param>

        public static implicit operator CloudServiceUpgradeMode(string value)
        {
            return new CloudServiceUpgradeMode(value);
        }

        /// <summary>Implicit operator to convert CloudServiceUpgradeMode to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="CloudServiceUpgradeMode" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum CloudServiceUpgradeMode</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode e1, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum CloudServiceUpgradeMode</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode e1, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode e2)
        {
            return e2.Equals(e1);
        }
    }
}