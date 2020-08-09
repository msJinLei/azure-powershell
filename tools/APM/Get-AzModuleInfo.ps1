# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

function Get-AzModuleInfo {
    [OutputType([System.Collections.ArrayList])]
    [CmdletBinding(DefaultParameterSetName='ListLocal', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='ListLocal', HelpMessage='The modules to retrieve information of.')]
        [Parameter(ParameterSetName='ListRemote', HelpMessage='The modules to retrieve information of.')]
        [System.Array]
        ${Module},

        [Parameter(ParameterSetName='ListRemote', Mandatory,  HelpMessage = 'The Registered Repostory.')]
        [System.String]
        ${Repository},

        [Parameter(ParameterSetName='ListRemote', HelpMessage='Whether to retrieve the latest versions.')]
        [System.Management.Automation.SwitchParameter]
        ${Latest}
    )

    process {
        $modules = New-Object System.Collections.ArrayList

        if($PSBoundParameters.ContainsKey('Repository'))
        {
            if ($PSBoundParameters.ContainsKey('Module'))
            {
                if($PSBoundParameters.ContainsKey('Latest'))
                {
                    $null = $PSBoundParameters['Module'] | ForEach-Object {
                        $tempModules = Find-Module -Name $_ -Repository $PSBoundParameters['Repository']
                        $tempModules | ForEach-Object { $modules.Add($_) }
                    }
                }
                else
                {
                    $null = $PSBoundParameters['Module'] | ForEach-Object {
                        $mAllVersions = Find-Module -Name $_ -Repository $PSBoundParameters['Repository'] -AllVersions
                        $mAllVersions | ForEach-Object {$modules.Add($_)}
                    }
                }
            }
            else
            {
                $azModule = Find-Module -Name Az -Repository $PSBoundParameters['Repository']
                if($azModule)
                {
                    Write-Host "Find Module Az"
                    $null = $modules.Add($azModule)
                    $dependencies = $azModule.Dependencies | ForEach-Object {$_['Name']} | ForEach-Object {
                         Write-Host "Try to Find Module", $_
                         Find-Module -Name $_ -Repository $PSBoundParameters['Repository'] 
                        }
                    $null = $dependencies | ForEach-Object {$modules.Add($_)}
                }
            }
        }
        else
        {
            if ($PSBoundParameters.ContainsKey('Module'))
            {
                $null = $PSBoundParameters.ContainsKey('Module') | Foreach-Object {
                    $tempModules = Get-Module -ListAvailable -Name $_
                    if($tempModules)
                    {
                        $modules.AddRange($tempModules)
                    }
                }
            }
            else
            {
                $null = Get-Module -ListAvailable -Name Az* | Foreach-Object {$modules.AddRange($_)}
            }
        }
        return $modules
    }
}

