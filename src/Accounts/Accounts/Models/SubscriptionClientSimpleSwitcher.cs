// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections.Generic;
using SubscriptionAndTenantHelperVersion2016 = Microsoft.Azure.Commands.ResourceManager.Common.Utilities.SubscriptionAndTenantHelper;
using SubscriptionAndTenantHelperVersion2019 = Microsoft.Azure.Commands.ResourceManager.Common.Utilities.Version2019_06_01.SubscriptionAndTenantHelper;

namespace Microsoft.Azure.Commands.Profile.Models
{
    static public class SubscriptionClientVersion
    {
        static public string ApiVersion;
        public static class property
        {
            public const string SubscriptionClientApiVersion = "SubscriptionClientApiVersion",
                SubscriptionClientSwitchDisabled = "SubscriptionClientSwitchDisabled";
        }
    }

    class SubscriptionClientSimpleSwitcher : ISubscriptionClientSwitcher
    {
        public SubscriptionClientSimpleSwitcher()
        {
            useLatestSubscriptionClient = !SubscriptionClientVersion.ApiVersion.StartsWith("2016");
        }

        public List<AzureTenant> ListAccountTenants(IAccessToken accessToken, IAzureEnvironment environment)
        {
            if (useLatestSubscriptionClient)
            {
                return new SubscriptionAndTenantHelperVersion2019().ListAccountTenants(accessToken, environment);
            }
            return new SubscriptionAndTenantHelperVersion2016().ListAccountTenants(accessToken, environment);
        }

        public IEnumerable<AzureSubscription> ListAllSubscriptionsForTenant(IAccessToken accessToken, IAzureAccount account, IAzureEnvironment environment)
        {
            if (useLatestSubscriptionClient)
            {
                return new SubscriptionAndTenantHelperVersion2019().ListAllSubscriptionsForTenant(accessToken, account, environment);
            }
            return new SubscriptionAndTenantHelperVersion2016().ListAllSubscriptionsForTenant(accessToken, account, environment);
        }

        public AzureSubscription GetSubscriptionById(string subscriptionId, IAccessToken accessToken, IAzureAccount account, IAzureEnvironment environment)
        {
            if (useLatestSubscriptionClient)
            {
                return new SubscriptionAndTenantHelperVersion2019().GetSubscriptionById(subscriptionId, accessToken, account, environment);
            }
            return new SubscriptionAndTenantHelperVersion2016().GetSubscriptionById(subscriptionId, accessToken, account, environment);
        }

        private bool useLatestSubscriptionClient = true;
        public void Reset()
        {

        }
    }
}