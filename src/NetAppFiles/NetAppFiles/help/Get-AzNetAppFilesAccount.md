---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/get-aznetappfilesaccount
schema: 2.0.0
---

# Get-AzNetAppFilesAccount

## SYNOPSIS
Gets details of an Azure NetApp Files (ANF) account.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzNetAppFilesAccount -ResourceGroupName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzNetAppFilesAccount -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetAppFilesAccount** cmdlet gets details of an ANF account.

## EXAMPLES

### Example 1: Get an ANF account
```powershell
Get-AzNetAppFilesAccount -ResourceGroupName "MyRG" -Name "MyAnfAccount"
```

```output
Location          : westus2
Id                : /subscriptions/mySubs/resourceGroups/MyRG/providers/Microsoft.NetApp/netAppAccounts/MyAnfAccount
Name              : MyAnfAccount
Type              : Microsoft.NetApp/netAppAccounts
Tags              :
ProvisioningState : Succeeded
```

This command gets the account named MyAnfAccount.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases: AccountName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the ANF account

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccount

## NOTES

## RELATED LINKS

[New-AzNetAppFilesAccount](./New-AzNetAppFilesAccount.md)
[Remove-AzNetAppFilesAccount](./Remove-AzNetAppFilesAccount.md)
[Set-AzNetAppFilesAccount](./Set-AzNetAppFilesAccount.md)
[Update-AzNetAppFilesAccount](./Update-AzNetAppFilesAccount.md)
[Get-AzNetAppFilesActiveDirectory](./Get-AzNetAppFilesActiveDirectory.md)
[New-AzNetAppFilesActiveDirectory](./New-AzNetAppFilesActiveDirectory.md)
[Remove-AzNetAppFilesActiveDirectory](./Remove-AzNetAppFilesActiveDirectory.md)
[Update-AzNetAppFilesActiveDirectory](./Update-AzNetAppFilesActiveDirectory.md)
