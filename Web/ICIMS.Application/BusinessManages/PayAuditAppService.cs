
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
    /// PayAudit应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class PayAuditAppService : ICIMSAppServiceBase, IPayAuditAppService
    {
        private readonly IRepository<PayAudit, int> _entityRepository;

        private readonly IPayAuditManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public PayAuditAppService(
        IRepository<PayAudit, int> entityRepository
        ,IPayAuditManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取PayAudit的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(PayAuditPermissions.Query)] 
        public async Task<PagedResultDto<PayAuditListDto>> GetPaged(GetPayAuditsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<PayAuditListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<PayAuditListDto>>();

			return new PagedResultDto<PayAuditListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取PayAuditListDto信息
		/// </summary>
		//[AbpAuthorize(PayAuditPermissions.Query)] 
		public async Task<PayAuditListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<PayAuditListDto>();
		}

		/// <summary>
		/// 获取编辑 PayAudit
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditPermissions.Create,PayAuditPermissions.Edit)]
		public async Task<GetPayAuditForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetPayAuditForEditOutput();
PayAuditEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<PayAuditEditDto>();

				//payAuditEditDto = ObjectMapper.Map<List<payAuditEditDto>>(entity);
			}
			else
			{
				editDto = new PayAuditEditDto();
			}

			output.PayAudit = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改PayAudit的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditPermissions.Create,PayAuditPermissions.Edit)]
		public async Task<PayAuditEditDto> CreateOrUpdate(CreateOrUpdatePayAuditInput input)
		{

			if (input.PayAudit.Id>0)
			{
			   return 	await Update(input.PayAudit);
			}
			else
			{
				return await Create(input.PayAudit);
			}
		}


		/// <summary>
		/// 新增PayAudit
		/// </summary>
		//[AbpAuthorize(PayAuditPermissions.Create)]
		protected virtual async Task<PayAuditEditDto> Create(PayAuditEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <PayAudit>(input);
            var entity=input.MapTo<PayAudit>();
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.PaymentName == input.PaymentName);
            if (item != null)
            {
                throw new UserFriendlyException("已存在相同名称,请重新输入");
            }

            input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
            return input;
		}

		/// <summary>
		/// 编辑PayAudit
		/// </summary>
		//[AbpAuthorize(PayAuditPermissions.Edit)]
		protected virtual async Task<PayAuditEditDto> Update(PayAuditEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);
            entity.LastModifierUserId = AbpSession.UserId;
            entity.LastModificationTime = DateTime.Now;
			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<PayAuditEditDto>();
		}



		/// <summary>
		/// 删除PayAudit信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除PayAudit的方法
		/// </summary>
		//[AbpAuthorize(PayAuditPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出PayAudit为excel表,等待开发。
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


