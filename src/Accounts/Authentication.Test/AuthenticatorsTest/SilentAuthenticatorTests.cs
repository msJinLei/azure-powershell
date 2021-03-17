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

using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Authentication.Test.Mocks;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Moq;

using Xunit;
using Xunit.Abstractions;

namespace Common.Authenticators.Test
{
    public class SilentAuthenticatorTests
    {
        private const string TestTenantId = "123";
        private const string TestResourceId = "ActiveDirectoryServiceEndpointResourceId";

        private const string accessToken = "fakertoken";

        private ITestOutputHelper Output { get; set; }

        class TokenCredentialMock : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(new AccessToken(accessToken, DateTimeOffset.Now));
            }
        }

        public SilentAuthenticatorTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
            Output = output;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task SimpleSilentAuthenticationTest()
        {
            var accountId = "testuser";

            //Setup
            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            mockAzureCredentialFactory.Setup(f => f.CreateCredentialsFromOptions()).Returns(() => new TokenCredentialMock());
            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
            InMemoryTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();

            var account = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(TestTenantId);

            var parameter = new SilentParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account.Id,
                accountId);

            //Run
            var authenticator = new SilentAuthenticator();
            var token = await authenticator.Authenticate(parameter);

            //Verify
            mockAzureCredentialFactory.Verify();
            Assert.Equal(accessToken, token.AccessToken);
            Assert.Equal(TestTenantId, token.TenantId);
        }
    }
}
