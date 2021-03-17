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

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.Graph.RBAC.Version1_6.Models;

namespace Microsoft.Azure.PowerShell.Authenticators.Factories
{
    public class AzureCredentialFactory
    {
        public TokenCredentialOptions Options { get; set; }

        public string ClientId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string TenantId { get; set; }

        public virtual TokenCredential CreateManagedIdentityCredential(string clientId)
        {
            return new ManagedIdentityCredential(clientId);
        }

        public virtual TokenCredential CreateCredentialsFromOptions()
        {
            if (Options is UsernamePasswordCredentialOptions)
            {
                return new UsernamePasswordCredential(UserName, Password, TenantId, ClientId, Options as UsernamePasswordCredentialOptions);
            }
            else if(Options is SharedTokenCacheCredentialOptions)
            {
                return new SharedTokenCacheCredential(Options as SharedTokenCacheCredentialOptions);
            }
            else if(Options is InteractiveBrowserCredentialOptions)
            {
                return new InteractiveBrowserCredential(Options as InteractiveBrowserCredentialOptions);
            }
            return null;
        }
    }
}
