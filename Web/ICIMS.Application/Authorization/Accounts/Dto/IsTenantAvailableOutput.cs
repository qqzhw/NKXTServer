namespace ICIMS.Authorization.Accounts.Dto
{
    public class IsTenantAvailableOutput
    {
        public TenantAvailabilityState State { get; set; }

        public int? TenantId { get; set; }
        public string TenancyName { get; set; }
        public IsTenantAvailableOutput()
        {
        }

        public IsTenantAvailableOutput(TenantAvailabilityState state, int? tenantId = null,string tenancyName="")
        {
            State = state;
            TenantId = tenantId;
            TenancyName = tenancyName;
        }
    }
}
