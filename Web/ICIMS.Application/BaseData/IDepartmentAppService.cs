using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ICIMS.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICIMS.BaseData
{
    public interface IDepartmentAppService: IApplicationService
    {
        Task<PagedResultDto<OrganizationUnitListDto>> GetPaged(GetContractCategorysInput input);
        

    }
}
