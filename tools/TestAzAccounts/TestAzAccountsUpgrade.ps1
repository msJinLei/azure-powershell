[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [string]
    $AzVersionUpgradeFrom,

    [Parameter(Mandatory = $true)]
    [string]
    $NugetPath,

    [Parameter(Mandatory = $true)]
    [string]
    $Path,

    [Parameter(Mandatory = $true)]
    [string]
    $PfxFileName,

    [Parameter()]
    [switch]
    $ClearContext,

    [Parameter(Mandatory = $true)]
    [string]
    $FederatedToken
)

$accountsVersion = Set-TestEnvironment -AzVersion $AzVersionUpgradeFrom -NugetPath $NugetPath

$importAzAccounts = "Import-Module Az.Accounts -RequiredVersion $accountsVersion`n"
$getToken = "Import-Module Az.Accounts`nGet-AzAccessToken"

$baseCommand = '''."$PSScriptRoot/ConnectAzAccountLiveTest.ps1" -ServicePrincipalName "AzAccountsTest" -CredentialPrefix "AzAccountsTest"'''
$baseCommand += " -ClearContext:$($ClearContext.IsPresent)"
$smokeTest = '''(Invoke-WebRequest -Uri "https://raw.githubusercontent.com/Azure/azure-powershell/main/tools/Test/SmokeTest/RmCoreSmokeTests.ps1").Content | Invoke-Expression'''

Write-Host '--------------------Test ClientSecret------------------------------------'
Write-Host 'Test Upgrade From Previous Version:'
$passwordCommand = $baseCommand + " -UsePassword`n"
$command = $importAzAccounts + $passwordCommand
Invoke-PowerShellCommand -ScriptBlock $command

Invoke-PowerShellCommand -ScriptBlock $getToken

Write-Host 'Connect AzAccounts Using Test Version:'
$command = $passwordCommand + $smokeTest
Invoke-PowerShellCommand -ScriptBlock $command

Write-Host '--------------------Test ClientCertificateFile---------------------------'
Write-Host 'Test Upgrade From Previous Version:'
$fileCommand = $baseCommand + " -UseCertificateFile -Path $Path -PfxFileName $PfxFileName`n"
$command = $importAzAccounts + $fileCommand
Invoke-PowerShellCommand -ScriptBlock $command

Invoke-PowerShellCommand -ScriptBlock $getToken

Write-Host 'Connect AzAccounts Using Test Version:'
$command = $fileCommand + $smokeTest
Invoke-PowerShellCommand -ScriptBlock $command

Write-Host '--------------------Test ClientCertificateThumbprint---------------------'
Write-Host 'Test Upgrade From Previous Version:'
$thumbprintCommand = $baseCommand + " -UseThumbprint`n"
$command = $importAzAccounts + $thumbprintCommand
Invoke-PowerShellCommand -ScriptBlock $command

Invoke-PowerShellCommand -ScriptBlock $getToken

Write-Host 'Connect AzAccounts Using Test Version:'
$command = $thumbprintCommand + $smokeTest
Invoke-PowerShellCommand -ScriptBlock $command

Write-Host '--------------------Test ClientAssertion---------------------------------'
Write-Host 'Test Upgrade From Previous Version:'
$federatedCommand = $baseCommand + " -FederatedToken $FederatedToken -UseFederatedToke`n"
$command = $importAzAccounts + $federatedCommand
Invoke-PowerShellCommand -ScriptBlock $command

Invoke-PowerShellCommand -ScriptBlock $getToken

Write-Host 'Connect AzAccounts Using Test Version:'
$command = $federatedCommand + $smokeTest
Invoke-PowerShellCommand -ScriptBlock $command

function Invoke-PowerShellCommand
{
    param (
        [Parameter(Mandatory)]
        [bool] $UseWindowsPowerShell,
    
        [Parameter(Mandatory, ParameterSetName = "ByScriptFile")]
        [ValidateNotNullOrEmpty()]
        [string] $ScriptFile,
    
        [Parameter(Mandatory, ParameterSetName = "ByScriptBlock")]
        [ValidateNotNullOrEmpty()]
        [string] $ScriptBlock
    )
    
    if ($UseWindowsPowerShell) {
        $process = "powershell"
        Write-Host "##[section]Using Windows PowerShell"
    }
    else {
        $process = "pwsh"
        Write-Host "##[section]Using PowerShell"
        pwsh -NoLogo -NoProfile -NonInteractive -Version
    }
    
    switch ($PSCmdlet.ParameterSetName) {
        "ByScriptFile" {
            Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -File $ScriptFile"
        }
        "ByScriptBlock" {
            Invoke-Expression "$process -NoLogo -NoProfile -NonInteractive -Command $ScriptBlock"
        }
    }
}

function Set-TestEnvironment
{
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $AzVersion,
    
        [Parameter(Mandatory = $true)]
        [string]
        $NugetPath
    )
    
    $module = Find-Module -name Az -RequiredVersion $AzVersion
    if ($null -ne $module)
    {
        Install-AzModule -RequiredAzVersion $AzVersion -UseExactAccountVersion -Repository PSGallery
    }
    else
    {
        throw "The specified version $AzVersion is not found in PSGallery."
    }
    $accountsVersion = ($module.Dependencies | Where-Object {$_.Name -eq "Az.Accounts"}).MinimumVersion
    Install-AzModule -Path $NugetPath

    $accountsVersion
}

