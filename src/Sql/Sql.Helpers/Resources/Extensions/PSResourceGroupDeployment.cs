using Microsoft.Azure.PowerShell.Cmdlets.Sql.Helpers.Resources.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sql.Resources.Extensions
{
    public class PSResourceGroupDeployment : PSDeploymentObject
    {
        public string ResourceGroupName { get; set; }

        public OnErrorDeploymentExtended OnErrorDeployment { get; set; }
    }
}