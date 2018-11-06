
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
    /// BuyCategory应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BuyCategoryAppService : ICIMSAppServiceBase, IBuyCategoryAppService
    {
        private readonly IRepository<BuyCategory, int> _entityRepository;

        private readonly IBuyCategoryManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BuyCategoryAppService(
        IRepository<BuyCategory, int> entityRepository
        ,IBuyCategoryManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取BuyCategory的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(BuyCategoryPermissions.Query)] 
        public async Task<PagedResultDto<BuyCategoryListDto>> GetPaged(GetBuyCategorysInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<BuyCategoryListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<BuyCategoryListDto>>();

			return new PagedResultDto<BuyCategoryListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取BuyCategoryListDto信息
		/// </summary>
		[AbpAuthorize(BuyCategoryPermissions.Query)] 
		public async Task<BuyCategoryListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BuyCategoryListDto>();
		}

		/// <summary>
		/// 获取编辑 BuyCategory
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BuyCategoryPermissions.Create,BuyCategoryPermissions.Edit)]
		public async Task<GetBuyCategoryForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetBuyCategoryForEditOutput();
BuyCategoryEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<BuyCategoryEditDto>();

				//buyCategoryEditDto = ObjectMapper.Map<List<buyCategoryEditDto>>(entity);
			}
			else
			{
				editDto = new BuyCategoryEditDto();
			}

			output.BuyCategory = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改BuyCategory的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BuyCategoryPermissions.Create,BuyCategoryPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBuyCategoryInput input)
		{

			if (input.BuyCategory.Id.HasValue)
			{
				await Update(input.BuyCategory);
			}
			else
			{
				await Create(input.BuyCategory);
			}
		}


		/// <summary>
		/// 新增BuyCategory
		/// </summary>
		[AbpAuthorize(BuyCategoryPermissions.Create)]
		protected virtual async Task<BuyCategoryEditDto> Create(BuyCategoryEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <BuyCategory>(input);
            var entity=input.MapTo<BuyCategory>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<BuyCategoryEditDto>();
		}

		/// <summary>
		/// 编辑BuyCategory
		/// </summary>
		[AbpAuthorize(BuyCategoryPermissions.Edit)]
		protected virtual async Task Update(BuyCategoryEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除BuyCategory信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BuyCategoryPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除BuyCategory的方法
		/// </summary>
		[AbpAuthorize(BuyCategoryPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出BuyCategory为excel表,等待开发。
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


