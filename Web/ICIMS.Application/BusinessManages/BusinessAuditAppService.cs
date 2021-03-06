
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
    /// BusinessAudit应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class BusinessAuditAppService : ICIMSAppServiceBase, IBusinessAuditAppService
    {
        private readonly IRepository<BusinessAudit, int> _entityRepository;
        private readonly IRepository<BusinessType, int> _businessRepository;
        private readonly IBusinessAuditManager _entityManager;
        private readonly IRepository<BusinessAuditStatus, int> _businessauditStatusRepository;
        /// <summary>
        /// 构造函数 
        ///</summary>
        public BusinessAuditAppService(
        IRepository<BusinessAudit, int> entityRepository, IRepository<BusinessAuditStatus, int> businessauditStatusRepository
        , IBusinessAuditManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
            _businessauditStatusRepository = businessauditStatusRepository;
        }


        /// <summary>
        /// 获取BusinessAudit的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(BuinessAuditPermissions.Query)] 
        public async Task<PagedResultDto<BusinessAuditListDto>> GetAllAuditStatus(GetBusinessAuditsInput input)
        {

            var queryaudit = _entityRepository.GetAll();
            var querystatus = _businessauditStatusRepository.GetAll();
            if (input.EntityId>0)
            {
                querystatus = querystatus.Where(o => o.EntityId == input.EntityId);
            }
            var query = (from o in queryaudit
                         join s in querystatus on o.Id equals s.BusinessAuditId
                         into temp
                         from tt in temp.DefaultIfEmpty()
                         where o.BusinessTypeName == input.BusinessTypeName 
                         select new BusinessAuditListDto
                         {
                             BusinessTypeId = o.BusinessTypeId,
                             BusinessTypeName = o.BusinessTypeName,
                             DisplayOrder = o.DisplayOrder,
                             Name = o.Name,
                             Status = tt != null ? tt.Status : 0,
                             EntityId = tt != null ? tt.EntityId : 0,
                             RoleId = o.RoleId,
                             Id = o.Id,
                             BusinessAuditStatusId = tt != null ? tt.Id : 0,
                             RoleName = o.Name
                         });

            //into temp    from tt in temp.DefaultIfEmpty()

            // TODO:根据传入的参数添加过滤条件
            //if (input.BusinessTypeId.HasValue)
            //{
            //    query = query.Where(o => o.BusinessType.Id == input.BusinessTypeId);
            //}
            //if (!string.IsNullOrEmpty(input.BusinessTypeName))
            //{
            //    query = query.Where(o => o.BusinessType.Name == input.BusinessTypeName);
            //}
            int s2 = 0;
            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(o => o.DisplayOrder).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            //var entityListDtos = ObjectMapper.Map<List<BuinessAuditListDto>>(entityList);
            // var entityListDtos = entityList.MapTo<List<BusinessAuditListDto>>();

            return new PagedResultDto<BusinessAuditListDto>(count, entityList);
        }

        public async Task<PagedResultDto<BusinessAuditListDto>> GetPaged(GetBusinessAuditsInput input)
        {

            var query = _entityRepository.GetAll();
            var a = _entityRepository.FirstOrDefault(1);
            // TODO:根据传入的参数添加过滤条件
            if (input.BusinessTypeId.HasValue)
            {
                query = query.Where(o => o.BusinessType.Id == input.BusinessTypeId);
            }
            if (!string.IsNullOrEmpty(input.BusinessTypeName))
            {
                query = query.Where(o => o.BusinessType.Name == input.BusinessTypeName);
            }
            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(o=>o.DisplayOrder).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            //var entityListDtos = ObjectMapper.Map<List<BuinessAuditListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<BusinessAuditListDto>>();

            return new PagedResultDto<BusinessAuditListDto>(count, entityListDtos);
        }

        /// <summary>
        /// 通过指定id获取BuinessAuditListDto信息
        /// </summary>
        //[AbpAuthorize(BuinessAuditPermissions.Query)] 
        public async Task<BusinessAuditListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<BusinessAuditListDto>();
		}

		/// <summary>
		/// 获取编辑 BusinessAudit
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BuinessAuditPermissions.Create,BuinessAuditPermissions.Edit)]
		public async Task<GetBusinessAuditForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetBusinessAuditForEditOutput();
BusinessAuditEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<BusinessAuditEditDto>();

				//buinessAuditEditDto = ObjectMapper.Map<List<buinessAuditEditDto>>(entity);
			}
			else
			{
				editDto = new BusinessAuditEditDto();
			}

			output.BusinessAudit = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改BuinessAudit的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BuinessAuditPermissions.Create,BuinessAuditPermissions.Edit)]
		public async Task<BusinessAuditEditDto> CreateOrUpdate(CreateOrUpdateBusinessAuditInput input)
		{

			if (input.BusinessAudit.Id>0)
			{
				var entity = await Update(input.BusinessAudit);

                return entity.MapTo<BusinessAuditEditDto>();
			}
			else
			{
				return await Create(input.BusinessAudit);
			}
		}


		/// <summary>
		/// 新增BusinessAudit
		/// </summary>
		//[AbpAuthorize(BuinessAuditPermissions.Create)]
		protected virtual async Task<BusinessAuditEditDto> Create(BusinessAuditEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <BuinessAudit>(input);
            var entity=input.MapTo<BusinessAudit>(); 
			input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
			return input;
		}

		/// <summary>
		/// 编辑BuinessAudit
		/// </summary>
		//[AbpAuthorize(BuinessAuditPermissions.Edit)]
		protected virtual async Task<BusinessAuditEditDto> Update(BusinessAuditEditDto input)
		{
            //TODO:更新前的逻辑判断，是否允许更新
            input.TenantId = AbpSession.TenantId;
            var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<BusinessAuditEditDto>();
		}



		/// <summary>
		/// 删除BuinessAudit信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(BuinessAuditPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除BuinessAudit的方法
		/// </summary>
		//[AbpAuthorize(BuinessAuditPermissions.BatchDelete)]
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


