
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


using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;
using ICIMS.BusinessManages.DomainService;
using ICIMS.BusinessManages.Authorization;


namespace ICIMS.BusinessManages
{
    /// <summary>
    /// ItemDefine应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ItemDefineAppService : ICIMSAppServiceBase, IItemDefineAppService
    {
        private readonly IRepository<ItemDefine, int> _entityRepository;

        private readonly IItemDefineManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ItemDefineAppService(
        IRepository<ItemDefine, int> entityRepository
        ,IItemDefineManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取ItemDefine的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(ItemDefinePermissions.Query)] 
        public async Task<PagedResultDto<ItemDefineListDto>> GetPaged(GetItemDefinesInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ItemDefineListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ItemDefineListDto>>();

			return new PagedResultDto<ItemDefineListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ItemDefineListDto信息
		/// </summary>
		//[AbpAuthorize(ItemDefinePermissions.Query)] 
		public async Task<ItemDefineListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ItemDefineListDto>();
		}

		/// <summary>
		/// 获取编辑 ItemDefine
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ItemDefinePermissions.Create,ItemDefinePermissions.Edit)]
		public async Task<GetItemDefineForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetItemDefineForEditOutput();
ItemDefineEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ItemDefineEditDto>();

				//itemDefineEditDto = ObjectMapper.Map<List<itemDefineEditDto>>(entity);
			}
			else
			{
				editDto = new ItemDefineEditDto();
			}

			output.ItemDefine = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改ItemDefine的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ItemDefinePermissions.Create,ItemDefinePermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateItemDefineInput input)
		{

			if (input.ItemDefine.Id.HasValue)
			{
				await Update(input.ItemDefine);
			}
			else
			{
				await Create(input.ItemDefine);
			}
		}


		/// <summary>
		/// 新增ItemDefine
		/// </summary>
		//[AbpAuthorize(ItemDefinePermissions.Create)]
		protected virtual async Task<ItemDefineEditDto> Create(ItemDefineEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <ItemDefine>(input);
            var entity=input.MapTo<ItemDefine>();
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.ItemName == input.ItemName);
            if (item != null)
            {
                throw new UserFriendlyException("已存在相同的项目名称,请重新输入");
            }

            input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
			return input;
		}

		/// <summary>
		/// 编辑ItemDefine
		/// </summary>
		//[AbpAuthorize(ItemDefinePermissions.Edit)]
		protected virtual async Task<ItemDefineEditDto> Update(ItemDefineEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<ItemDefineEditDto>();
		}



		/// <summary>
		/// 删除ItemDefine信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ItemDefinePermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除ItemDefine的方法
		/// </summary>
		//[AbpAuthorize(ItemDefinePermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出ItemDefine为excel表,等待开发。
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


