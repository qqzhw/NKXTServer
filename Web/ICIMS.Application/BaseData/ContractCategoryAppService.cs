
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using ICIMS.BaseData;
using ICIMS.BaseData.Dtos;
using ICIMS.BaseData.DomainService;
using ICIMS.BaseData.Authorization;
using Abp;

namespace ICIMS.BaseData
{
    /// <summary>
    /// ContractCategory应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ContractCategoryAppService : ICIMSAppServiceBase, IContractCategoryAppService
    {
        private readonly IRepository<ContractCategory, int> _entityRepository;

        private readonly IContractCategoryManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ContractCategoryAppService(
        IRepository<ContractCategory, int> entityRepository
        ,IContractCategoryManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取ContractCategory的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(ContractCategoryPermissions.Query)] 
        public async Task<PagedResultDto<ContractCategoryListDto>> GetPaged(GetContractCategorysInput input)
		{

		    var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件
            if (!string.IsNullOrEmpty(input.No))
            {
                query = query.Where(o => o.No.Contains(input.No));
            }
            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.Where(o => o.Name.Contains(input.Name));
            }
            var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ContractCategoryListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ContractCategoryListDto>>();

			return new PagedResultDto<ContractCategoryListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ContractCategoryListDto信息
		/// </summary>
		//[AbpAuthorize(ContractCategoryPermissions.Query)] 
		public async Task<ContractCategoryListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ContractCategoryListDto>();
		}

		/// <summary>
		/// 获取编辑 ContractCategory
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ContractCategoryPermissions.Create,ContractCategoryPermissions.Edit)]
		public async Task<GetContractCategoryForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetContractCategoryForEditOutput();
ContractCategoryEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ContractCategoryEditDto>();

				//contractCategoryEditDto = ObjectMapper.Map<List<contractCategoryEditDto>>(entity);
			}
			else
			{
				editDto = new ContractCategoryEditDto();
			}

			output.ContractCategory = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改ContractCategory的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ContractCategoryPermissions.Create,ContractCategoryPermissions.Edit)]
		public async Task<ContractCategoryEditDto> CreateOrUpdate(CreateOrUpdateContractCategoryInput input)
		{

			if (input.ContractCategory.Id>0)
			{
				return await Update(input.ContractCategory);
			}
			else
			{
				return await Create(input.ContractCategory);
			}
		}


		/// <summary>
		/// 新增ContractCategory
		/// </summary>
		//[AbpAuthorize(ContractCategoryPermissions.Create)]
		protected virtual async Task<ContractCategoryEditDto> Create(ContractCategoryEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <ContractCategory>(input);
            var entity=input.MapTo<ContractCategory>();

            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }
            var id = await _entityRepository.InsertAndGetIdAsync(entity);
            input.Id = id;
            return input;
		}

		/// <summary>
		/// 编辑ContractCategory
		/// </summary>
		//[AbpAuthorize(ContractCategoryPermissions.Edit)]
		protected virtual async Task<ContractCategoryEditDto> Update(ContractCategoryEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No&o.Id!=input.Id);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }
            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<ContractCategoryEditDto>();
        }



		/// <summary>
		/// 删除ContractCategory信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ContractCategoryPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除ContractCategory的方法
		/// </summary>
		//[AbpAuthorize(ContractCategoryPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出ContractCategory为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


