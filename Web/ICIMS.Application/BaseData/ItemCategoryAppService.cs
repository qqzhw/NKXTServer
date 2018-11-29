
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


namespace ICIMS.BaseData
{
    /// <summary>
    /// ItemCategory应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ItemCategoryAppService : ICIMSAppServiceBase, IItemCategoryAppService
    {
        private readonly IRepository<ItemCategory, int> _entityRepository;

        private readonly IItemCategoryManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ItemCategoryAppService(
        IRepository<ItemCategory, int> entityRepository
        ,IItemCategoryManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取ItemCategory的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(ItemCategoryPermissions.Query)] 
        public async Task<PagedResultDto<ItemCategoryListDto>> GetPaged(GetItemCategorysInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ItemCategoryListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ItemCategoryListDto>>();

			return new PagedResultDto<ItemCategoryListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ItemCategoryListDto信息
		/// </summary>
		//[AbpAuthorize(ItemCategoryPermissions.Query)] 
		public async Task<ItemCategoryListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ItemCategoryListDto>();
		}

		/// <summary>
		/// 获取编辑 ItemCategory
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ItemCategoryPermissions.Create,ItemCategoryPermissions.Edit)]
		public async Task<GetItemCategoryForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetItemCategoryForEditOutput();
ItemCategoryEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ItemCategoryEditDto>();

				//itemCategoryEditDto = ObjectMapper.Map<List<itemCategoryEditDto>>(entity);
			}
			else
			{
				editDto = new ItemCategoryEditDto();
			}

			output.ItemCategory = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改ItemCategory的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ItemCategoryPermissions.Create,ItemCategoryPermissions.Edit)]
		public async Task<ItemCategoryEditDto> CreateOrUpdate(CreateOrUpdateItemCategoryInput input)
		{

			if (input.ItemCategory.Id>0)
			{
				return await Update(input.ItemCategory);
			}
			else
			{
				return await Create(input.ItemCategory);
			}
		}


		/// <summary>
		/// 新增ItemCategory
		/// </summary>
		//[AbpAuthorize(ItemCategoryPermissions.Create)]
		protected virtual async Task<ItemCategoryEditDto> Create(ItemCategoryEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <ItemCategory>(input);
            var entity=input.MapTo<ItemCategory>();
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }

            input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
            return input;
		}

		/// <summary>
		/// 编辑ItemCategory
		/// </summary>
		//[AbpAuthorize(ItemCategoryPermissions.Edit)]
		protected virtual async Task<ItemCategoryEditDto> Update(ItemCategoryEditDto input)
		{
            //TODO:更新前的逻辑判断，是否允许更新
            input.TenantId = AbpSession.TenantId;
            var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No & o.Id != input.Id);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }
            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<ItemCategoryEditDto>();
		}



		/// <summary>
		/// 删除ItemCategory信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ItemCategoryPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除ItemCategory的方法
		/// </summary>
		//[AbpAuthorize(ItemCategoryPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出ItemCategory为excel表,等待开发。
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


