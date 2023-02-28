namespace Microsoft.Azure.PowerShell.Cmdlets.Sql.Resources.Extensions
{
    public class PSDeploymentOperation
    {
        public string Id { get; set; }

        public string OperationId { get; set; }

        public string ProvisioningState { get; set; }

        public string StatusCode { get; set; }

        public object StatusMessage { get; set; }

        public string TargetResource { get; set; }
    }
}