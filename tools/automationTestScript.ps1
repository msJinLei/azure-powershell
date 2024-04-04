Param(
)

Write-Output $PSVersionTable
$IDENTITY_ENDPOINT = $env:IDENTITY_ENDPOINT
$IDENTITY_HEADER = $env:IDENTITY_HEADER
Write-Output "IDENTITY_ENDPOINT=$IDENTITY_ENDPOINT"
Write-Output "IDENTITY_HEADER=$IDENTITY_HEADER"

# Ensures you do not inherit an AzContext in your runbook
Disable-AzContextAutosave -Scope Process | Out-Null

Connect-AzAccount -Identity
Write-Output (Get-AzAccessToken)

$i = 0
while ($i -ne 30)
{
    $uri = "${IDENTITY_ENDPOINT}?api-version=2019-07-01-preview&resource=https%3A%2F%2Fmanagement.core.windows.net%2F"
    $response = Invoke-RestMethod $uri -Method "Get" -Headers @{secret="${IDENTITY_HEADER}"}
    Write-Output $error
    Write-Output $response
    Start-Sleep 10
    $i++
}
