using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ICIMS.MultiTenancy.Dto;

namespace ICIMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
