#### Background
- CAE https://docs.microsoft.com/en-us/azure/active-directory/conditional-access/concept-continuous-access-evaluation
- Conditional Acess https://docs.microsoft.com/en-us/azure/active-directory/conditional-access/overview

#### Preparation
- Login Portal to directory 54826b22-38d6-4fb2-bad9-b7b93a3e9c5a
- Create a new test account
  - https://portal.azure.com/#blade/Microsoft_AAD_IAM/UsersManagementMenuBlade/MsGraphUsers
- Add test account to cae user group
  - https://portal.azure.com/#blade/Microsoft_AAD_IAM/GroupDetailsMenuBlade/Overview/groupId/8b0b28c9-f1a2-41c7-a633-704e47c0f671
- Check cae policy in conditonal access
  - https://portal.azure.com/#blade/Microsoft_AAD_IAM/ConditionalAccessBlade/Policies
  - Already set, double confirm
- Set location policy in conditional access
  - https://portal.azure.com/#blade/Microsoft_AAD_IAM/ConditionalAccessBlade/Policies
- Set $DebugPreference = 'Continue'

#### Test case 1
- Connect-AzAccounts using the test account
- Check Access Token and MSGraph Token
  - Get-AzAccessToken AT0
  - Get-AzAccessToken -ResourceTypeName "MSGraph" GraphAT0
- Revoke the current session
  - Invoke-AzRestMethod https://graph.microsoft.com/v1.0/me/revokeSignInSessions -Method POST
- Wait 30 mins or 150 mins
- Retrieve data using AT0 and GraphAT0
  - Get-AzSubscription
    - Response is 400 (reauth failed)
  - Get-AzAdApplication -DisplayName 'icm_ljin'
    - Response is 400 (reauth failed)
- Connect-AzAccounts using the test account
- Check Access Token
  - Get-AzSubscription
    - Response is 200 (reauth succeed)
  - Get-AzAccessToken
    - AT0 should be updated to AT1
- Check MSGraph Token
  - Get-AzAccessToken -ResourceTypeName "MSGraph"
    - GraphAT0 is not updated
  - Get-AzAdApplication -DisplayName 'icm_ljin'
    - Response is 200 (reauth succeed)
  - Get-AzAccessToken -ResourceTypeName "MSGraph"
    - GraphAT0 is updated to GraphAT1

#### Test case 2
- Connect-AzAccounts using the test account of the allowed ip
- Check Access Token and MSGraph Token
  - Get-AzAccessToken AT0
  - Get-AzAccessToken -ResourceTypeName "MSGraph" GraphAT0
- Switch to the ip in the blocked ip ranged
- Try to retrieve data
  - Get-AzSubscription
    - Response is 400 (reauth failed)
  - Get-AzAdApplication -DisplayName 'icm_ljin'
    - Response is 400 (reauth failed)
- Switch to the ip in the allowed ip ranged
- Check Access Token
  - Get-AzSubscription
    - Response is 200
  - Get-AzAccessToken
    - AT0 is not upated
- Check MSGraph Token
  - Get-AzAdApplication -DisplayName 'icm_ljin'
    - Response is 200
  - Get-AzAccessToken -ResourceTypeName "MSGraph"
    - AT0 is not upated