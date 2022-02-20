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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

using System.Runtime.InteropServices;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class AzKeyStore : IDisposable
    {
        public const string Name = "AzKeyStore";
        private static readonly IDictionary<IKeyStoreKey, SecureString> _credentials = new Dictionary<IKeyStoreKey, SecureString>();

        [Obsolete("The constructor is deprecated. Will read key from encryted storage later.", false)]
        public AzKeyStore(IAzureContextContainer profile)
        {
            ImportProfile(profile);
        }

        public void ImportProfile(IAzureContextContainer profile)
        {
            if (profile != null && profile.Accounts != null)
            {
                foreach (var account in profile.Accounts)
                {
                    if (account != null)
                    {
                        if (account.ExtendedProperties.ContainsKey(AzureAccount.Property.ServicePrincipalSecret))
                        {
                            IKeyStoreKey keyStoreKey = new ServicePrincipalKey(AzureAccount.Property.ServicePrincipalSecret, account.Id
                                , account.GetTenants().FirstOrDefault());
                            var servicePrincipalSecret = account.GetProperty(AzureAccount.Property.ServicePrincipalSecret);
                            _credentials[keyStoreKey] = servicePrincipalSecret.ConvertToSecureString();
                        }
                        if (account.ExtendedProperties.ContainsKey(AzureAccount.Property.CertificatePassword))
                        {
                            IKeyStoreKey keyStoreKey = new ServicePrincipalKey(AzureAccount.Property.CertificatePassword, account.Id
                                , account.GetTenants().FirstOrDefault());
                            var certificatePassword = account.GetProperty(AzureAccount.Property.CertificatePassword);
                            _credentials[keyStoreKey] = certificatePassword.ConvertToSecureString();
                        }
                    }
                }
            }
        }

        public AzKeyStore(string directory, string fileName, IAzureContextContainer profile)
        {
            //fixme
            try
            {
                try
                {
                    var storageProperties = new StorageCreationPropertiesBuilder(fileName, directory)
                        .WithMacKeyChain(KeyChainServiceName + ".other_secrets", KeyChainAccountName)
                        .WithLinuxKeyring(LinuxKeyRingSchema, LinuxKeyRingCollection, LinuxKeyRingLabel, LinuxKeyRingAttr1,
                               new KeyValuePair<string, string>("other_secrets", "secret_description"));
                    _storage = Storage.Create(storageProperties.Build());
                    _storage.VerifyPersistence();
                }
                catch (Exception e)
                {
                    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        //should not happen: _storage = null;
                        throw new PSInvalidOperationException(e.Message);
                    }
                    var storageProperties = new StorageCreationPropertiesBuilder(fileName, directory).WithMacKeyChain(KeyChainServiceName + ".other_secrets", KeyChainAccountName)
                        .WithUnprotectedFile();
                    _storage = Storage.Create(storageProperties.Build());
                    _storage.VerifyPersistence();
                }
            }
            catch (Exception e)
            {
                _storage = null;
            }

            ImportProfile(profile);

            try
            {
                var data = _storage.ReadData();
                if (data != null && data.Length > 0)
                {
                    var rawJsonString = Encoding.UTF8.GetString(data);
                    var serializableKeyStore = JsonConvert.DeserializeObject(rawJsonString, typeof(List<KeyStoreElement>)) as List<KeyStoreElement>;
                    if (serializableKeyStore != null)
                    {
                        foreach (var item in serializableKeyStore)
                        {
                            Type type = Type.GetType(item.keyType);
                            IKeyStoreKey keyStoreKey = JsonConvert.DeserializeObject(item.keyStoreKey, type) as IKeyStoreKey;
                            if (keyStoreKey != null)
                            {
                                _credentials[keyStoreKey] = ConvertToSecureString(item.secret);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public void ClearCache()
        {
            _credentials.Clear();
        }

        public void Dispose()
        {
            ClearCache();
        }

        public void SaveKey(IKeyStoreKey key, SecureString value)
        {
            _credentials[key] = value;
        }

        public SecureString GetKey(IKeyStoreKey key)
        {
            if (_credentials.ContainsKey(key))
            {
                return _credentials[key];
            }
            return null;
        }

        public bool DeleteKey(IKeyStoreKey key)
        {
            return _credentials.Remove(key);
        }
    }
}
