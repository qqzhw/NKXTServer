
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
 
using ICIMS.BussinesManages.Dtos;
using ICIMS.BussinesManages.DomainService;
using ICIMS.BussinesManages.Authorization;


namespace ICIMS.BussinesManages
{
    /// <summary>
    /// BusinessType应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BusinessTypeAppService : ICIMSAppServiceBase, IBusinessTypeAppService
    {
        private readonly IRepository<BusinessType, int> _entityRepository;

        private readonly IBusinessTypeManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BusinessTypeAppService(
        IRepository<BusinessType, int> entityRepository
        ,IBusinessTypeManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取BusinessType的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(BusinessTypePermissions.Query)] 
        public async Task<PagedResultDto<BusinessTypeListDto>> GetPaged(GetBusinessTypesInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<BusinessTypeListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<BusinessTypeListDto>>();

			return new PagedResultDto<BusinessTypeListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取BusinessTypeListDto信息
		/// </summary>
		//[AbpAuthorize(BusinessTypePermissions.Query)] 
		public async Task<BusinessTypeListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BusinessTypeListDto>();
		}

		/// <summary>
		/// 获取编辑 BusinessType
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BusinessTypePermissions.Create,BusinessTypePermissions.Edit)]
		public async Task<GetBusinessTypeForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetBusinessTypeForEditOutput();
BusinessTypeEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<BusinessTypeEditDto>();

				//businessTypeEditDto = ObjectMapper.Map<List<businessTypeEditDto>>(entity);
			}
			else
			{
				editDto = new BusinessTypeEditDto();
			}

			output.BusinessType = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改BusinessType的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BusinessTypePermissions.Create,BusinessTypePermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBusinessTypeInput input)
		{

			if (input.BusinessType.Id.HasValue)
			{
				await Update(input.BusinessType);
			}
			else
			{
				await Create(input.BusinessType);
			}
		}


		/// <summary>
		/// 新增BusinessType
		/// </summary>
		//[AbpAuthorize(BusinessTypePermissions.Create)]
		protected virtual async Task<BusinessTypeEditDto> Create(BusinessTypeEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <BusinessType>(input);
            var entity=input.MapTo<BusinessType>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<BusinessTypeEditDto>();
		}

		/// <summary>
		/// 编辑BusinessType
		/// </summary>
		//[AbpAuthorize(BusinessTypePermissions.Edit)]
		protected virtual async Task Update(BusinessTypeEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除BusinessType信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BusinessTypePermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除BusinessType的方法
		/// </summary>
		//[AbpAuthorize(BusinessTypePermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出BusinessType为excel表,等待开发。
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


