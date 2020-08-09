$ps1Files = Get-ChildItem -Path $PSScriptRoot -Recurse -Include '*.ps1' -File
Write-Host $ps1Files
$ps1Files | ForEach-Object { . $_.FullName }
Export-ModuleMember -Function $ps1Files.Basename
