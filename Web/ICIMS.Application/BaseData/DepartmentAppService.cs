using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Session;
using Abp.UI;
using ICIMS.BaseData.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace ICIMS.BaseData
{
   public class DepartmentAppService: ICIMSAppServiceBase, IDepartmentAppService
    {
        private IRepository<OrganizationUnit, long> _organizationUnitRepository;
        public DepartmentAppService(IRepository<OrganizationUnit, long>  organizationUnitRepository)
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


        [UnitOfWork]
        public virtual async Task<OrganizationUnit> CreateAsync(OrganizationUnit organizationUnit)
        {
            organizationUnit.TenantId = AbpSession.TenantId;
            //organizationUnit.Code = await GetNextChildCodeAsync(organizationUnit.ParentId);
            await ValidateOrganizationUnitAsync(organizationUnit);
            return await _organizationUnitRepository.InsertAsync(organizationUnit);
        }

        public virtual async Task<OrganizationUnit> UpdateAsync(OrganizationUnit organizationUnit)
        {
            organizationUnit.TenantId = AbpSession.TenantId;
            var oriItem = await _organizationUnitRepository.GetAsync(organizationUnit.Id);
            //organizationUnit.MapTo(oriItem);
            oriItem.DisplayName = organizationUnit.DisplayName;
            organizationUnit.Code = organizationUnit.Code;
            //Mapper.Map(organizationUnit, oriItem);
            //oriItem = organizationUnit;
            await ValidateOrganizationUnitAsync(oriItem);
            return await _organizationUnitRepository.UpdateAsync(oriItem);
        }

        public virtual async Task<string> GetNextChildCodeAsync(long? parentId)
        {
            var lastChild = await GetLastChildOrNullAsync(parentId);
            if (lastChild == null)
            {
                var parentCode = parentId != null ? await GetCodeAsync(parentId.Value) : null;
                return OrganizationUnit.AppendCode(parentCode, OrganizationUnit.CreateCode(1));
            }

            return OrganizationUnit.CalculateNextCode(lastChild.Code);
        }

        public virtual async Task<OrganizationUnit> GetLastChildOrNullAsync(long? parentId)
        {
            var children = await _organizationUnitRepository.GetAllListAsync(ou => ou.ParentId == parentId);
            return children.OrderBy(c => c.Code).LastOrDefault();
        }

        public virtual async Task<string> GetCodeAsync(long id)
        {
            return (await _organizationUnitRepository.GetAsync(id)).Code;
        }

        [UnitOfWork]
        public virtual async Task DeleteAsync(long id)
        {
            var children = await FindChildrenAsync(id, true);

            foreach (var child in children)
            {
                await _organizationUnitRepository.DeleteAsync(child);
            }

            await _organizationUnitRepository.DeleteAsync(id);
        }

        [UnitOfWork]
        public virtual async Task MoveAsync(long id, long? parentId)
        {
            var organizationUnit = await _organizationUnitRepository.GetAsync(id);
            if (organizationUnit.ParentId == parentId)
            {
                return;
            }

            //Should find children before Code change
            var children = await FindChildrenAsync(id, true);

            //Store old code of OU
            var oldCode = organizationUnit.Code;

            //Move OU
            //organizationUnit.Code = await GetNextChildCodeAsync(parentId);
            organizationUnit.ParentId = parentId;

            await ValidateOrganizationUnitAsync(organizationUnit);

            //Update Children Codes
            foreach (var child in children)
            {
                child.Code = OrganizationUnit.AppendCode(organizationUnit.Code, OrganizationUnit.GetRelativeCode(child.Code, oldCode));
            }
        }

        public async Task<List<OrganizationUnit>> FindChildrenAsync(long? parentId, bool recursive = false)
        {
            if (!recursive)
            {
                return await _organizationUnitRepository.GetAllListAsync(ou => ou.ParentId == parentId);
            }

            if (!parentId.HasValue)
            {
                return await _organizationUnitRepository.GetAllListAsync();
            }

            var code = await GetCodeAsync(parentId.Value);

            return await _organizationUnitRepository.GetAllListAsync(
                ou => ou.Code.StartsWith(code) && ou.Id != parentId.Value
            );
        }

        protected virtual async Task ValidateOrganizationUnitAsync(OrganizationUnit organizationUnit)
        {
            var siblings = (await FindChildrenAsync(organizationUnit.ParentId))
                .Where(ou => ou.Id != organizationUnit.Id)
                .ToList();

            if (siblings.Any(ou => ou.DisplayName == organizationUnit.DisplayName))
            {
                throw new UserFriendlyException(L("OrganizationUnitDuplicateDisplayNameWarning", organizationUnit.DisplayName));
            }
        }

    }
}
