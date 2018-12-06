
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
    /// PayAuditDetail应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class PayAuditDetailAppService : ICIMSAppServiceBase, IPayAuditDetailAppService
    {
        private readonly IRepository<PayAuditDetail, int> _entityRepository;

        private readonly IPayAuditDetailManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public PayAuditDetailAppService(
        IRepository<PayAuditDetail, int> entityRepository
        ,IPayAuditDetailManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取PayAuditDetail的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(PayAuditDetailPermissions.Query)] 
        public async Task<PagedResultDto<PayAuditDetailListDto>> GetPaged(GetPayAuditDetailsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<PayAuditDetailListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<PayAuditDetailListDto>>();

			return new PagedResultDto<PayAuditDetailListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取PayAuditDetailListDto信息
		/// </summary>
		//[AbpAuthorize(PayAuditDetailPermissions.Query)] 
		public async Task<PayAuditDetailListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<PayAuditDetailListDto>();
		}

		/// <summary>
		/// 获取编辑 PayAuditDetail
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditDetailPermissions.Create,PayAuditDetailPermissions.Edit)]
		public async Task<GetPayAuditDetailForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetPayAuditDetailForEditOutput();
PayAuditDetailEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<PayAuditDetailEditDto>();

				//payAuditDetailEditDto = ObjectMapper.Map<List<payAuditDetailEditDto>>(entity);
			}
			else
			{
				editDto = new PayAuditDetailEditDto();
			}

			output.PayAuditDetail = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改PayAuditDetail的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditDetailPermissions.Create,PayAuditDetailPermissions.Edit)]
		public async Task<PayAuditDetailEditDto> CreateOrUpdate(CreateOrUpdatePayAuditDetailInput input)
		{

			if (input.PayAuditDetail.Id>0)
			{
			return await Update(input.PayAuditDetail);
			}
			else
			{
				return await Create(input.PayAuditDetail);
			}
		}


		/// <summary>
		/// 新增PayAuditDetail
		/// </summary>
		//[AbpAuthorize(PayAuditDetailPermissions.Create)]
		protected virtual async Task<PayAuditDetailEditDto> Create(PayAuditDetailEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <PayAuditDetail>(input);
            var entity=input.MapTo<PayAuditDetail>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<PayAuditDetailEditDto>();
		}

		/// <summary>
		/// 编辑PayAuditDetail
		/// </summary>
		//[AbpAuthorize(PayAuditDetailPermissions.Edit)]
		protected virtual async Task<PayAuditDetailEditDto> Update(PayAuditDetailEditDto input)
		{
            //TODO:更新前的逻辑判断，是否允许更新
            input.TenantId = AbpSession.TenantId;
            var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<PayAuditDetailEditDto>();
		}



		/// <summary>
		/// 删除PayAuditDetail信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditDetailPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除PayAuditDetail的方法
		/// </summary>
		//[AbpAuthorize(PayAuditDetailPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出PayAuditDetail为excel表,等待开发。
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


