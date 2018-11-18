
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
    /// BuinessAudit应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BuinessAuditAppService : ICIMSAppServiceBase, IBuinessAuditAppService
    {
        private readonly IRepository<BuinessAudit, int> _entityRepository;

        private readonly IBuinessAuditManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BuinessAuditAppService(
        IRepository<BuinessAudit, int> entityRepository
        ,IBuinessAuditManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取BuinessAudit的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(BuinessAuditPermissions.Query)] 
        public async Task<PagedResultDto<BuinessAuditListDto>> GetPaged(GetBuinessAuditsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<BuinessAuditListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<BuinessAuditListDto>>();

			return new PagedResultDto<BuinessAuditListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取BuinessAuditListDto信息
		/// </summary>
		[AbpAuthorize(BuinessAuditPermissions.Query)] 
		public async Task<BuinessAuditListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BuinessAuditListDto>();
		}

		/// <summary>
		/// 获取编辑 BuinessAudit
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BuinessAuditPermissions.Create,BuinessAuditPermissions.Edit)]
		public async Task<GetBuinessAuditForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetBuinessAuditForEditOutput();
BuinessAuditEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<BuinessAuditEditDto>();

				//buinessAuditEditDto = ObjectMapper.Map<List<buinessAuditEditDto>>(entity);
			}
			else
			{
				editDto = new BuinessAuditEditDto();
			}

			output.BuinessAudit = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改BuinessAudit的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BuinessAuditPermissions.Create,BuinessAuditPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateBuinessAuditInput input)
		{

			if (input.BuinessAudit.Id.HasValue)
			{
				await Update(input.BuinessAudit);
			}
			else
			{
				await Create(input.BuinessAudit);
			}
		}


		/// <summary>
		/// 新增BuinessAudit
		/// </summary>
		[AbpAuthorize(BuinessAuditPermissions.Create)]
		protected virtual async Task<BuinessAuditEditDto> Create(BuinessAuditEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <BuinessAudit>(input);
            var entity=input.MapTo<BuinessAudit>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<BuinessAuditEditDto>();
		}

		/// <summary>
		/// 编辑BuinessAudit
		/// </summary>
		[AbpAuthorize(BuinessAuditPermissions.Edit)]
		protected virtual async Task Update(BuinessAuditEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除BuinessAudit信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(BuinessAuditPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除BuinessAudit的方法
		/// </summary>
		[AbpAuthorize(BuinessAuditPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出BuinessAudit为excel表,等待开发。
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


