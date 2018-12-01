
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
    /// UserManageUnit应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class UserManageUnitAppService : ICIMSAppServiceBase, IUserManageUnitAppService
    {
        private readonly IRepository<UserManageUnit, int> _entityRepository;

        private readonly IUserManageUnitManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public UserManageUnitAppService(
        IRepository<UserManageUnit, int> entityRepository
        ,IUserManageUnitManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取UserManageUnit的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(UserManageUnitPermissions.Query)] 
        public async Task<PagedResultDto<UserManageUnitListDto>> GetPaged(GetUserManageUnitsInput input)
		{

		    var query = _entityRepository.GetAll();
            // TODO:根据传入的参数添加过滤条件

            if (input.UserId.HasValue)
            {
                query = query.Where(o=>o.UserId==input.UserId);
            }
			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<UserManageUnitListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<UserManageUnitListDto>>();

			return new PagedResultDto<UserManageUnitListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取UserManageUnitListDto信息
		/// </summary>
		//[AbpAuthorize(UserManageUnitPermissions.Query)] 
		public async Task<UserManageUnitListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<UserManageUnitListDto>();
		}

		/// <summary>
		/// 获取编辑 UserManageUnit
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(UserManageUnitPermissions.Create,UserManageUnitPermissions.Edit)]
		public async Task<GetUserManageUnitForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetUserManageUnitForEditOutput();
UserManageUnitEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<UserManageUnitEditDto>();

				//userManageUnitEditDto = ObjectMapper.Map<List<userManageUnitEditDto>>(entity);
			}
			else
			{
				editDto = new UserManageUnitEditDto();
			}

			output.UserManageUnit = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改UserManageUnit的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(UserManageUnitPermissions.Create,UserManageUnitPermissions.Edit)]
		public async Task<UserManageUnitEditDto> CreateOrUpdate(CreateOrUpdateUserManageUnitInput input)
		{

			if (input.UserManageUnit.Id.HasValue)
			{
				return await Update(input.UserManageUnit);
			}
			else
			{
				return await Create(input.UserManageUnit);
			}
		}


		/// <summary>
		/// 新增UserManageUnit
		/// </summary>
		//[AbpAuthorize(UserManageUnitPermissions.Create)]
		protected virtual async Task<UserManageUnitEditDto> Create(UserManageUnitEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <UserManageUnit>(input);
            var entity=input.MapTo<UserManageUnit>();

            entity.TenantId = AbpSession.TenantId;
			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<UserManageUnitEditDto>();
		}

		/// <summary>
		/// 编辑UserManageUnit
		/// </summary>
		//[AbpAuthorize(UserManageUnitPermissions.Edit)]
		protected virtual async Task<UserManageUnitEditDto> Update(UserManageUnitEditDto input)
		{
            //TODO:更新前的逻辑判断，是否允许更新
            
			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<UserManageUnitEditDto>();
		}



		/// <summary>
		/// 删除UserManageUnit信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(UserManageUnitPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除UserManageUnit的方法
		/// </summary>
		//[AbpAuthorize(UserManageUnitPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出UserManageUnit为excel表,等待开发。
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


