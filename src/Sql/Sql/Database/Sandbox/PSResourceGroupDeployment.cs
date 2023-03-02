using Microsoft.Azure.PowerShell.Cmdlets.Sql.Helpers.Resources.Models;

namespace Microsoft.Azure.Commands.Sql.Database.Sandbox
{
    public class PSResourceGroupDeployment : PSDeploymentObject
    {
        public string ResourceGroupName { get; set; }

        public OnErrorDeploymentExtended OnErrorDeployment { get; set; }
    }
}