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
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using SubscriptionClientVersion2016 = Microsoft.Azure.Commands.ResourceManager.Common.Utilities.SubscriptionClientWrapper;
using SubscriptionClientVersion2019 = Microsoft.Azure.Commands.ResourceManager.Common.Utilities.Version2019_06_01.SubscriptionClientWrapper;

namespace Microsoft.Azure.Commands.Profile.Models
{
    class SubscriptionClientProxy : ISubscriptionClientCommon
    {
        static private Queue<ISubscriptionClientCommon> clients = new Queue<ISubscriptionClientCommon>();

        public delegate void LoggerWriter(string message);

        private LoggerWriter WriteWarningMessage = null;

        public SubscriptionClientProxy(LoggerWriter logWriter)
        {
            clients.Clear();
            clients.Enqueue(new SubscriptionClientVersion2019());
            clients.Enqueue(new SubscriptionClientVersion2016());
            WriteWarningMessage = logWriter;
        }

        public List<AzureTenant> ListAccountTenants(IAccessToken accessToken, IAzureEnvironment environment)
        {
            while (clients.Count > 0)
            {
                try
                {
                    return clients.Peek().ListAccountTenants(accessToken, environment);
                }
                catch (CloudException e)
                {
                    if (e.Body == null || string.IsNullOrEmpty(e.Body.Code) || !e.Body.Code.Equals("InvalidApiVersionParameter"))
                    {
                        throw e;
                    }
                    WriteWarningMessage($"Failed to use the latest Api of subscription client: {e.Message}");
                    clients.Dequeue();

                }
            }
            throw new CloudException("Your Api version is not supported by Azure server.");
        }

        public IEnumerable<AzureSubscription> ListAllSubscriptionsForTenant(IAccessToken accessToken, IAzureAccount account, IAzureEnvironment environment)
        {
            while (clients.Count > 0)
            {
                try
                {
                    return clients.Peek().ListAllSubscriptionsForTenant(accessToken, account, environment);
                }
                catch (CloudException e)
                {
                    if (e.Body == null || string.IsNullOrEmpty(e.Body.Code) || !e.Body.Code.Equals("InvalidApiVersionParameter"))
                    {
                        throw e;
                    }
                    WriteWarningMessage($"Failed to use the latest Api of subscription client: {e.Message}");
                    clients.Dequeue();

                }
            }
            throw new CloudException("Your Api version is not supported by Azure server.");
        }

        public AzureSubscription GetSubscriptionById(string subscriptionId, IAccessToken accessToken, IAzureAccount account, IAzureEnvironment environment)
        {
            while (clients.Count > 0)
            {
                try
                {
                    return clients.Peek().GetSubscriptionById(subscriptionId, accessToken, account, environment);
                }
                catch (CloudException e)
                {
                    if (e.Body == null || string.IsNullOrEmpty(e.Body.Code) || !e.Body.Code.Equals("InvalidApiVersionParameter"))
                    {
                        throw e;
                    }
                    WriteWarningMessage($"Failed to use the latest Api of subscription client: {e.Message}");
                    clients.Dequeue();

                }
            }
            throw new CloudException("Your Api version is not supported by Azure server.");;
        }

        public string ApiVersion
        {
            get
            {
                return 0 < clients.Count ? clients.Peek().ApiVersion : string.Empty;
            }
        }
    }
}
