
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
    /// AuditMapping应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class AuditMappingAppService : ICIMSAppServiceBase, IAuditMappingAppService
    {
        private readonly IRepository<AuditMapping, int> _entityRepository;

        private readonly IAuditMappingManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public AuditMappingAppService(
        IRepository<AuditMapping, int> entityRepository
        ,IAuditMappingManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取AuditMapping的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(AuditMappingPermissions.Query)] 
        public async Task<PagedResultDto<AuditMappingListDto>> GetPaged(GetAuditMappingsInput input)
		{

		    var query = _entityRepository.GetAllIncluding(o=>o.BusinessAudit);
            // TODO:根据传入的参数添加过滤条件
             
             
                query = query.Where(o => o.ItemId == input.ItemId);
             
         
			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<AuditMappingListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<AuditMappingListDto>>();

			return new PagedResultDto<AuditMappingListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取AuditMappingListDto信息
		/// </summary>
		//[AbpAuthorize(AuditMappingPermissions.Query)] 
		public async Task<AuditMappingListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<AuditMappingListDto>();
		}

		/// <summary>
		/// 获取编辑 AuditMapping
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(AuditMappingPermissions.Create,AuditMappingPermissions.Edit)]
		public async Task<GetAuditMappingForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetAuditMappingForEditOutput();
AuditMappingEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<AuditMappingEditDto>();

				//auditMappingEditDto = ObjectMapper.Map<List<auditMappingEditDto>>(entity);
			}
			else
			{
				editDto = new AuditMappingEditDto();
			}

			output.AuditMapping = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改AuditMapping的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(AuditMappingPermissions.Create,AuditMappingPermissions.Edit)]
		public async Task<AuditMappingEditDto> CreateOrUpdate(CreateOrUpdateAuditMappingInput input)
		{

			if (input.AuditMapping.Id.HasValue)
			{
				return await Update(input.AuditMapping);
			}
			else
			{
			  return	await Create(input.AuditMapping);
			}
		}


		/// <summary>
		/// 新增AuditMapping
		/// </summary>
		//[AbpAuthorize(AuditMappingPermissions.Create)]
		protected virtual async Task<AuditMappingEditDto> Create(AuditMappingEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <AuditMapping>(input);
            var entity=input.MapTo<AuditMapping>();

            entity.TenantId = AbpSession.TenantId;
            entity.AuditTime = DateTime.Now;
            entity.Status = 1;
            entity.CreatorUserId = AbpSession.UserId;
			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<AuditMappingEditDto>();
		}

		/// <summary>
		/// 编辑AuditMapping
		/// </summary>
		//[AbpAuthorize(AuditMappingPermissions.Edit)]
		protected virtual async Task<AuditMappingEditDto> Update(AuditMappingEditDto input)
		{
            //TODO:更新前的逻辑判断，是否允许更新
            input.TenantId = AbpSession.TenantId;
            var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		     await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<AuditMappingEditDto>();
		}



		/// <summary>
		/// 删除AuditMapping信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(AuditMappingPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除AuditMapping的方法
		/// </summary>
		//[AbpAuthorize(AuditMappingPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出AuditMapping为excel表,等待开发。
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


