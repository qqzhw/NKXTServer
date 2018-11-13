
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
    /// YSCategory应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class YSCategoryAppService : ICIMSAppServiceBase, IYSCategoryAppService
    {
        private readonly IRepository<YSCategory, int> _entityRepository;

        private readonly IYSCategoryManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public YSCategoryAppService(
        IRepository<YSCategory, int> entityRepository
        ,IYSCategoryManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取YSCategory的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(YSCategoryPermissions.Query)] 
        public async Task<PagedResultDto<YSCategoryListDto>> GetPaged(GetYSCategorysInput input)
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

			// var entityListDtos = ObjectMapper.Map<List<YSCategoryListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<YSCategoryListDto>>();

			return new PagedResultDto<YSCategoryListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取YSCategoryListDto信息
		/// </summary>
		//[AbpAuthorize(YSCategoryPermissions.Query)] 
		public async Task<YSCategoryListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<YSCategoryListDto>();
		}

		/// <summary>
		/// 获取编辑 YSCategory
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(YSCategoryPermissions.Create,YSCategoryPermissions.Edit)]
		public async Task<GetYSCategoryForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetYSCategoryForEditOutput();
YSCategoryEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<YSCategoryEditDto>();

				//ySCategoryEditDto = ObjectMapper.Map<List<ySCategoryEditDto>>(entity);
			}
			else
			{
				editDto = new YSCategoryEditDto();
			}

			output.YSCategory = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改YSCategory的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(YSCategoryPermissions.Create,YSCategoryPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateYSCategoryInput input)
		{

			if (input.YSCategory.Id.HasValue)
			{
				await Update(input.YSCategory);
			}
			else
			{
				await Create(input.YSCategory);
			}
		}


		/// <summary>
		/// 新增YSCategory
		/// </summary>
		//[AbpAuthorize(YSCategoryPermissions.Create)]
		protected virtual async Task<YSCategoryEditDto> Create(YSCategoryEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <YSCategory>(input);
            var entity=input.MapTo<YSCategory>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<YSCategoryEditDto>();
		}

		/// <summary>
		/// 编辑YSCategory
		/// </summary>
		//[AbpAuthorize(YSCategoryPermissions.Edit)]
		protected virtual async Task Update(YSCategoryEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除YSCategory信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(YSCategoryPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除YSCategory的方法
		/// </summary>
		//[AbpAuthorize(YSCategoryPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出YSCategory为excel表,等待开发。
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


