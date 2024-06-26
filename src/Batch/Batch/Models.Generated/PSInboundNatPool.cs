﻿// -----------------------------------------------------------------------------
﻿//
﻿// Copyright Microsoft Corporation
﻿// Licensed under the Apache License, Version 2.0 (the "License");
﻿// you may not use this file except in compliance with the License.
﻿// You may obtain a copy of the License at
﻿// http://www.apache.org/licenses/LICENSE-2.0
﻿// Unless required by applicable law or agreed to in writing, software
﻿// distributed under the License is distributed on an "AS IS" BASIS,
﻿// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
﻿// See the License for the specific language governing permissions and
﻿// limitations under the License.
﻿// -----------------------------------------------------------------------------
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:5.0.17
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Batch.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.Batch;
    
    
    public partial class PSInboundNatPool
    {
        
        internal Microsoft.Azure.Batch.InboundNatPool omObject;
        
        private IReadOnlyList<PSNetworkSecurityGroupRule> networkSecurityGroupRules;
        
        public PSInboundNatPool(string name, Microsoft.Azure.Batch.Common.InboundEndpointProtocol protocol, int backendPort, int frontendPortRangeStart, int frontendPortRangeEnd, System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Batch.NetworkSecurityGroupRule> networkSecurityGroupRules = null)
        {
            this.omObject = new Microsoft.Azure.Batch.InboundNatPool(name, protocol, backendPort, frontendPortRangeStart, frontendPortRangeEnd, networkSecurityGroupRules);
        }
        
        internal PSInboundNatPool(Microsoft.Azure.Batch.InboundNatPool omObject)
        {
            if ((omObject == null))
            {
                throw new System.ArgumentNullException("omObject");
            }
            this.omObject = omObject;
        }
        
        public int BackendPort
        {
            get
            {
                return this.omObject.BackendPort;
            }
        }
        
        public int FrontendPortRangeEnd
        {
            get
            {
                return this.omObject.FrontendPortRangeEnd;
            }
        }
        
        public int FrontendPortRangeStart
        {
            get
            {
                return this.omObject.FrontendPortRangeStart;
            }
        }
        
        public string Name
        {
            get
            {
                return this.omObject.Name;
            }
        }
        
        public IReadOnlyList<PSNetworkSecurityGroupRule> NetworkSecurityGroupRules
        {
            get
            {
                if (((this.networkSecurityGroupRules == null) 
                            && (this.omObject.NetworkSecurityGroupRules != null)))
                {
                    List<PSNetworkSecurityGroupRule> list;
                    list = new List<PSNetworkSecurityGroupRule>();
                    IEnumerator<Microsoft.Azure.Batch.NetworkSecurityGroupRule> enumerator;
                    enumerator = this.omObject.NetworkSecurityGroupRules.GetEnumerator();
                    for (
                    ; enumerator.MoveNext(); 
                    )
                    {
                        list.Add(new PSNetworkSecurityGroupRule(enumerator.Current));
                    }
                    this.networkSecurityGroupRules = list;
                }
                return this.networkSecurityGroupRules;
            }
        }
        
        public Microsoft.Azure.Batch.Common.InboundEndpointProtocol Protocol
        {
            get
            {
                return this.omObject.Protocol;
            }
        }
    }
}
