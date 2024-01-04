
[CmdletBinding()]
Param
(
    [Parameter(Mandatory = $true)]
    [string]
    $AutomationAccount,

    [Parameter(Mandatory = $true)]
    [string]
    $UserManagedIdentity,

    [Parameter(Mandatory = $true)]
    [string]
    $ResourceGroupName,

    [Parameter(Mandatory = $true)]
    [string]
    $Subscription,

    [Parameter(Mandatory = $true)]
    [string]
    $Location
)

#$ResourceGroupName = 'AzAccountsTest'
#$AutomationAccount = 'AzAccountsTestAutomation'
#$Location = 'eastus'
#$UserManagedIdentity = 'xUAMI'

if ($Subscription.Length -le 0)
{
    $Subscription = 'Azure SDK Powershell Test - Manual'
}
Set-AzContext -SubscriptionName $Subscription

$userIdentity = Get-AzUserAssignedIdentity -ResourceGroupName $ResourceGroupName -Name $UserManagedIdentity
$automationParams = @{
    'ResourceGroupName' = $ResourceGroupName;
    'Name' = $AutomationAccount;
    'Location' = $Location;
    'AssignSystemIdentity' = $true;
    'AssignUserIdentity' = $userIdentity.Id;
}

$autoAccount = New-AzAutomationAccount @automationParams

$roleDevTest = 'DevTest Labs User'
$roleReader = 'Reader'

New-AzRoleAssignment -ObjectId $autoAccount.Identity.PrincipalId -ResourceGroupName $ResourceGroupName -RoleDefinitionName $roleDevTest
New-AzRoleAssignment -ObjectId $autoAccount.Identity.PrincipalId -ResourceGroupName $ResourceGroupName -RoleDefinitionName $roleReader

New-AzRoleAssignment -ObjectId $userIdentity.PrincipalId -ResourceGroupName $ResourceGroupName -RoleDefinitionName $roleDevTest

$RunbookName = 'AzAccountsTestRunbook'
Import-AzAutomationRunbook -Path 'AzAccountsTestRunbook.ps1'  -Name $RunbookName -Type 'PowerShell' -AutomationAccountName $AutomationAccount -ResourceGroupName $ResourceGroupName -Force
Publish-AzAutomationRunbook -Name $RunbookName -AutomationAccountName $AutomationAccount  -ResourceGroupName $ResourceGroupName