using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Organizations;
using ICIMS.BaseData.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace ICIMS.BaseData
{
   public class DepartmentAppService: OrganizationUnitManager,IDepartmentAppService
    {
        private IRepository<OrganizationUnit, long> _organizationUnitRepository;
        public DepartmentAppService(IRepository<OrganizationUnit, long>  organizationUnitRepository):base(organizationUnitRepository)
        {
            _organizationUnitRepository = organizationUnitRepository;
        }

        public async Task<PagedResultDto<OrganizationUnitListDto>> GetPaged(GetContractCategorysInput input)
        {

            var query = _organizationUnitRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件
            //if (!string.IsNullOrEmpty(input.No))
            //{
            //    query = query.Where(o => o.No.Contains(input.No));
            //}
            //if (!string.IsNullOrEmpty(input.Name))
            //{
            //    query = query.Where(o => o.Name.Contains(input.Name));
            //}
            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.No).AsNoTracking() 
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<ContractCategoryListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<OrganizationUnitListDto>>();

            return new PagedResultDto<OrganizationUnitListDto>(count, entityListDtos);
        }

    }
}
