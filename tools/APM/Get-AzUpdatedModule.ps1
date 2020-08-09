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

function Get-AzUpdatedModule {
    [OutputType([System.Collections.ArrayList])]
    [CmdletBinding(DefaultParameterSetName='Default', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='Default', Mandatory, HelpMessage = 'The Registered Repostory.')]
        [System.String]
        ${Repository}
    )

    process {

        $modules = New-Object System.Collections.ArrayList

        if($PSBoundParameters.ContainsKey('Repository'))
        {
            $installModules = @{}
            $null = Get-InstalledModule -Name Az* | ForEach-Object {$installModules[$_.Name] = $_.Version}

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

            $modules = $modules.Where({[version]$_.Version -gt [version]$installModules[$_.Name]})
        }
        return $modules
    }
}

