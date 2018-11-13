
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

using ICIMS.BusinessManages.Dtos;
using ICIMS.BusinessManages.DomainService;
using ICIMS.BusinessManages.Authorization;


namespace ICIMS.BusinessManages
{
    /// <summary>
    /// Budget应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BudgetAppService : ICIMSAppServiceBase, IBudgetAppService
    {
        private readonly IRepository<Budget, int> _entityRepository;

        private readonly IBudgetManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BudgetAppService(
        IRepository<Budget, int> entityRepository
        ,IBudgetManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Budget的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(BudgetPermissions.Query)] 
        public async Task<PagedResultDto<BudgetListDto>> GetPaged(GetBudgetsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<BudgetListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<BudgetListDto>>();

			return new PagedResultDto<BudgetListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取BudgetListDto信息
		/// </summary>
		//[AbpAuthorize(BudgetPermissions.Query)] 
		public async Task<BudgetListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BudgetListDto>();
		}

		/// <summary>
		/// 获取编辑 Budget
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BudgetPermissions.Create,BudgetPermissions.Edit)]
		public async Task<GetBudgetForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetBudgetForEditOutput();
BudgetEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<BudgetEditDto>();

				//budgetEditDto = ObjectMapper.Map<List<budgetEditDto>>(entity);
			}
			else
			{
				editDto = new BudgetEditDto();
			}

			output.Budget = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Budget的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BudgetPermissions.Create,BudgetPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBudgetInput input)
		{

			if (input.Budget.Id.HasValue)
			{
				await Update(input.Budget);
			}
			else
			{
				await Create(input.Budget);
			}
		}


		/// <summary>
		/// 新增Budget
		/// </summary>
		//[AbpAuthorize(BudgetPermissions.Create)]
		protected virtual async Task<BudgetEditDto> Create(BudgetEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Budget>(input);
            var entity=input.MapTo<Budget>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<BudgetEditDto>();
		}

		/// <summary>
		/// 编辑Budget
		/// </summary>
		//[AbpAuthorize(BudgetPermissions.Edit)]
		protected virtual async Task Update(BudgetEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Budget信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BudgetPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Budget的方法
		/// </summary>
		//[AbpAuthorize(BudgetPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出Budget为excel表,等待开发。
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


