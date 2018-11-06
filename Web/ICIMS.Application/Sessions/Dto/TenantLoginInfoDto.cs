using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ICIMS.MultiTenancy;

namespace ICIMS.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
