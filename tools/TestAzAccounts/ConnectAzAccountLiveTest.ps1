[CmdletBinding()]
param (
    [Parameter(ParameterSetName = 'CertificateFile')]
    [Switch]
    $UseCertificateFile,

    [Parameter(ParameterSetName = 'Thumbprint')]
    [Switch]
    $UseThumbprint,

    [Parameter(ParameterSetName = 'Password')]
    [Switch]
    $UsePassword,

    [Parameter(ParameterSetName = 'FederatedToken')]
    [Switch]
    $UseFederatedToken,

    [Parameter(ParameterSetName = 'Thumbprint', Mandatory = $true)]
    [Parameter(ParameterSetName = 'CertificateFile', Mandatory = $true)]
    [string]
    $Path,

    [Parameter(ParameterSetName = 'Thumbprint', Mandatory = $true)]
    [Parameter(ParameterSetName = 'CertificateFile', Mandatory = $true)]
    [string]
    $PfxFileName,

    [Parameter(ParameterSetName = 'FederatedToken', Mandatory = $true)]
    [string]
    $FederatedToken,

    [Parameter()]
    [string]
    $KeyVaultName,

    [Parameter()]
    [string]
    $ServicePrincipalName,

    [Parameter()]
    [string]
    $CredentialPrefix,

    [Parameter()]
    [string]
    $TenantId,

    [Parameter()]
    [Switch]
    $ClearContext
)

$keyVaultName = if ($KeyVaultName) {$KeyVaultName} else {'LiveTestKeyVault'}
$servicePrincipalName = if ($ServicePrincipalName) {$ServicePrincipalName} else {'AzurePowerShellAzAccountsTest'}
$credentialPrefix = if ($CredentialPrefix) {$CredentialPrefix} else {'AzAccountsTest'}
$tenantId = if ($TenantId) {$TenantId} else {'54826b22-38d6-4fb2-bad9-b7b93a3e9c5a'}

$certificateName = "${credentialPrefix}Certificate"
$secretName = "${credentialPrefix}Secret"

$password = 'pa88w0rd!'

Set-AzContext -TenantId $tenantId
Import-Module "$PSScriptRoot/CertificateUtility.psm1"

if ($Path -and $PfxFileName) {
    $paramsCertificate = @{
        KeyVaultName      = $keyVaultName;
        CertificateName   = $certificateName;
        CertPlainPassword = $password;
        Path              = $Path
        PfxFileName       = $PfxFileName
    }
    $pfxFile = Get-CertificateFromKeyVault @paramsCertificate
}

$appId = (Get-AzADServicePrincipal -DisplayName $servicePrincipalName).AppId
$params = @{
    TenantId      = $tenantId;
    ApplicationId = $appId;
}
if ($PSCmdlet.ParameterSetName -eq 'CertificateFile') {
    $params['CertificatePath'] = $pfxFile
    $params['CertificatePassword'] = (ConvertTo-SecureString -String $password -AsPlainText -Force)
    if ($ClearContext) {
        Clear-AzContext
    }
    Connect-AzAccount -ServicePrincipal @params
}
elseif ($PSCmdlet.ParameterSetName -eq 'Thumbprint') {
    if (-not $IsWindows) {
        throw "NonWin System doesn't support Thumbprint Login currently."
    }
    $paramsImport = @{
        FilePath          = $pfxFile
        CertStoreLocation = 'Cert:\CurrentUser\My'
        Password          = (ConvertTo-SecureString -String $password -AsPlainText -Force)
    }
    Import-PfxCertificate @paramsImport

    $pfxCert = New-Object `
        -TypeName 'System.Security.Cryptography.X509Certificates.X509Certificate2' `
        -ArgumentList @($pfxFile, $password)
    $thumbprint = $pfxCert.Thumbprint
    Write-Host "thumbprint = $thumbprint"
    $params['CertificateThumbprint'] = $thumbprint
    if ($ClearContext) {
        Clear-AzContext
    }
    Connect-AzAccount -ServicePrincipal @params
}
elseif ($PSCmdlet.ParameterSetName -eq 'Password') {
    $secret = Get-AzKeyVaultSecret -VaultName $keyVaultName -Name $secretName
    $credential = New-Object -TypeName 'System.Management.Automation.PSCredential' -ArgumentList $appId, $secret.SecretValue
    if ($ClearContext) {
        Clear-AzContext
    }
    Connect-AzAccount -ServicePrincipal -TenantId $tenantId -Credential $credential
}
elseif ($PSCmdlet.ParameterSetName -eq 'FederatedToken') {
    $params['FederatedToken'] = $FederatedToken
    if ($ClearContext) {
        Clear-AzContext
    }
    Connect-AzAccount -ServicePrincipal @params
}

(Get-AzAccessToken).Token
