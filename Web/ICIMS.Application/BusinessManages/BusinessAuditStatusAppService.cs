
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



namespace ICIMS.BusinessManages
{
    /// <summary>
    /// BusinessAuditStatus应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BusinessAuditStatusAppService : ICIMSAppServiceBase, IBusinessAuditStatusAppService
    {
        private readonly IRepository<BusinessAuditStatus, int> _entityRepository;

        private readonly IBusinessAuditStatusManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public BusinessAuditStatusAppService(
        IRepository<BusinessAuditStatus, int> entityRepository
        ,IBusinessAuditStatusManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取BusinessAuditStatus的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		 
        public async Task<PagedResultDto<BusinessAuditStatusListDto>> GetPaged(GetBusinessAuditStatussInput input)
		{

		    var query = _entityRepository.GetAllIncluding(o=>o.BusinessAudit);
            if (input.Status.HasValue)
            {
                query = query.Where(o => o.Status == input.Status);
            }
            if (!string.IsNullOrEmpty(input.BusinessTypeName))
            {
                query = query.Where(o => o.BusinessTypeName == input.BusinessTypeName);
            }
            if (input.RoleIds.Count>0)
            {
                query = query.Where(o =>input.RoleIds.Contains(o.BusinessAudit.RoleId));
            }
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(o=>o.Status).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<BusinessAuditStatusListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<BusinessAuditStatusListDto>>();

			return new PagedResultDto<BusinessAuditStatusListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取BusinessAuditStatusListDto信息
		/// </summary>
		 
		public async Task<BusinessAuditStatusListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BusinessAuditStatusListDto>();
		}

		/// <summary>
		/// 获取编辑 BusinessAuditStatus
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task<GetBusinessAuditStatusForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetBusinessAuditStatusForEditOutput();
BusinessAuditStatusEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<BusinessAuditStatusEditDto>();

				//businessAuditStatusEditDto = ObjectMapper.Map<List<businessAuditStatusEditDto>>(entity);
			}
			else
			{
				editDto = new BusinessAuditStatusEditDto();
			}

			output.BusinessAuditStatus = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改BusinessAuditStatus的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task CreateOrUpdate(CreateOrUpdateBusinessAuditStatusInput input)
		{

			if (input.BusinessAuditStatus.Id>0)
			{
				await Update(input.BusinessAuditStatus);
			}
			else
			{
				await Create(input.BusinessAuditStatus);
			}
		}


		/// <summary>
		/// 新增BusinessAuditStatus
		/// </summary>
		
		protected virtual async Task<BusinessAuditStatusEditDto> Create(BusinessAuditStatusEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <BusinessAuditStatus>(input);
            var entity=input.MapTo<BusinessAuditStatus>();
			
            
			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<BusinessAuditStatusEditDto>();
		}

		/// <summary>
		/// 编辑BusinessAuditStatus
		/// </summary>
		
		protected virtual async Task Update(BusinessAuditStatusEditDto input)
		{
            //TODO:更新前的逻辑判断，是否允许更新
            input.TenantId = AbpSession.TenantId;
            var entity = await _entityRepository.GetAsync(input.Id);
            
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除BusinessAuditStatus信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除BusinessAuditStatus的方法
		/// </summary>
		
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出BusinessAuditStatus为excel表,等待开发。
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


