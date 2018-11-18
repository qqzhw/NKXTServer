using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Organizations;
using Abp.Runtime.Session;
using ICIMS.BaseData.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PagedResultDto<OrganizationUnitListDto>> GetPaged(GetOrganizationUnitsInput input)
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
                    .OrderBy("Code").AsNoTracking() 
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<ContractCategoryListDto>>(entityList);
            List<OrganizationUnitListDto> entityListDtos = entityList.MapTo<List<OrganizationUnitListDto>>();
            var aa = entityListDtos.FirstOrDefault();

            return new PagedResultDto<OrganizationUnitListDto>(count, entityListDtos);
        }

        //public async Task<FundFromEditDto> CreateOrUpdate(OrganizationUnitListDto input)
        //{

        //    if (input.Id > 0)
        //    {
        //        return await Update(input);
        //    }
        //    else
        //    {
        //        return await Create(input);
        //    }
        //}

        //protected virtual async Task<FundFromEditDto> Create(OrganizationUnitListDto input)
        //{
        //    //TODO:新增前的逻辑判断，是否允许新增
        //    input.TenantId = IAbpSession.TenantId;
        //    // var entity = ObjectMapper.Map <FundFrom>(input);
        //    var entity = input.MapTo<FundFrom>();

        //    var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No);
        //    if (item != null)
        //    {
        //        throw new UserFriendlyException("编号已存在,请重新输入");
        //    }

        //    int id = await _entityRepository.InsertAndGetIdAsync(entity);
        //    input.Id = id;
        //    return input;
        //}

        ///// <summary>
        ///// 编辑FundFrom
        ///// </summary>
        ////[AbpAuthorize(FundFromPermissions.Edit)]
        //protected virtual async Task<FundFromEditDto> Update(OrganizationUnitListDto input)
        //{
        //    //TODO:更新前的逻辑判断，是否允许更新

        //    var entity = await _entityRepository.GetAsync(input.Id);
        //    input.MapTo(entity);
        //    var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No & o.Id != input.Id);
        //    if (item != null)
        //    {
        //        throw new UserFriendlyException("编号已存在,请重新输入");
        //    }
        //    // ObjectMapper.Map(input, entity);
        //    await _entityRepository.UpdateAsync(entity);
        //    return entity.MapTo<FundFromEditDto>();
        //}

    }
}
