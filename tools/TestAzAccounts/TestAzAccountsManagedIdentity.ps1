[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [string]
    $ModulePath,

    [Parameter(Mandatory = $true)]
    [string]
    $ModuleVersion
)
$subscription = 'Azure SDK Powershell Test - Manual'
$resourceGroupName = 'AzAccountsTest'
$automationAccount = 'AzAccountsTestAutomation'
$location = 'eastus'
$userManagedIdentity = 'AzAccountsTestUMI'
$runbookName = 'AzAccountsTestRunbook'

Set-AzContext -SubscriptionName $subscription
New-AzResourceGroup -Name $ResourceGroupName -Location $Location

. "$PSScriptRoot/DeployUserManagedIdentity.ps1" -Tenant $tenantId -Subscription $subscription -ResourceGroupName $resourceGroupName`
                                                -UserManagedIdentity $userManagedIdentity -Location $location

. "$PSScriptRoot/DeployRunbook.ps1" -AutomationAccount $automationAccount -UserManagedIdentity $userManagedIdentity`
                                    -ResourceGroupName $resourceGroupName -Subscription $subscription -Location $location

$params = [ordered]@{
    "ResourceGroupName" = $resourceGroupName;
    "UserManagedIdentity" = $userManagedIdentity;
    "AutomationAccount" = $automationAccount;
    "Method" = "UA"
}
Set-AzAutomationModule -AutomationAccountName $automationAccount -Name 'Az.Accounts' -ContentLinkUri $ModulePath -ContentLinkVersion $ModuleVersion -ResourceGroupName $resourceGroupName
Start-AzAutomationRunbook -AutomationAccountName $automationAccount -Name $runbookName -ResourceGroupName $resourceGroupName -Parameters $params

Remove-AzAutomationAccount -Name $automationAccount -ResourceGroupName $resourceGroupName -Force