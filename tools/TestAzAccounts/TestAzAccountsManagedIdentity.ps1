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

Set-AzContext -SubscriptionName $subscription
New-AzResourceGroup -Name $ResourceGroupName -Location $Location

. "$PSScriptRoot/DeployRunbook.ps1" -AutomationAccount $automationAccount -IdentityType @('SystemAssigned', 'UserAssigned') -UserManagedIdentity $userManagedIdentity -ResourceGroupName $resourceGroupName -Subscription $subscription -Location $location
Set-AzAutomationModule -AutomationAccountName $automationAccount -Name 'Az.Accounts' -ContentLinkUri $ModulePath -ContentLinkVersion $ModuleVersion -ResourceGroupName $resourceGroupName

$runbookName = 'AzAccountsTestRunbook'
$params = [ordered]@{
    "ResourceGroupName" = $resourceGroupName;
    "UserManagedIdentity" = $userManagedIdentity;
    "AutomationAccount" = $automationAccount;
    "Method" = "UA"
}
Start-AzAutomationRunbook -AutomationAccountName $automationAccount -Name $runbookName -ResourceGroupName $resourceGroupName -Parameters $params
exit
$output = $null
while ($null-eq $output)
{
    $job = Get-AzAutomationJob -RunbookName $runbookName -AutomationAccountName $automationAccount -ResourceGroupName $resourceGroupName
    $output = Get-AzAutomationJobOutput -Id $job.JobId -AutomationAccountName $automationAccount -ResourceGroupName $resourceGroupName -Stream 'Any'
    Start-Sleep -Seconds 5
}

$errOutput = $output | Where-Object {$_.Type -eq 'Error'}
if ($null -eq $errOutput -or $errOutput.Count -eq 0)
{
    Write-Output "Job run successfully!"
    Remove-AzAutomationAccount -Name $automationAccount -ResourceGroupName $resourceGroupName -Force
}
else
{
    Write-Output "Job error count: $($errOutput.Count)"
}
