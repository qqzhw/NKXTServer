
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
using Abp;

namespace ICIMS.BaseData
{
    /// <summary>
    /// PaymentType应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class PaymentTypeAppService : ICIMSAppServiceBase, IPaymentTypeAppService
    {
        private readonly IRepository<PaymentType, int> _entityRepository;

        private readonly IPaymentTypeManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public PaymentTypeAppService(
        IRepository<PaymentType, int> entityRepository
        ,IPaymentTypeManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取PaymentType的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(PaymentTypePermissions.Query)] 
        public async Task<PagedResultDto<PaymentTypeListDto>> GetPaged(GetPaymentTypesInput input)
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

			// var entityListDtos = ObjectMapper.Map<List<PaymentTypeListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<PaymentTypeListDto>>();

			return new PagedResultDto<PaymentTypeListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取PaymentTypeListDto信息
		/// </summary>
		//[AbpAuthorize(PaymentTypePermissions.Query)] 
		public async Task<PaymentTypeListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<PaymentTypeListDto>();
		}

		/// <summary>
		/// 获取编辑 PaymentType
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PaymentTypePermissions.Create,PaymentTypePermissions.Edit)]
		public async Task<GetPaymentTypeForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetPaymentTypeForEditOutput();
PaymentTypeEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<PaymentTypeEditDto>();

				//paymentTypeEditDto = ObjectMapper.Map<List<paymentTypeEditDto>>(entity);
			}
			else
			{
				editDto = new PaymentTypeEditDto();
			}

			output.PaymentType = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改PaymentType的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PaymentTypePermissions.Create,PaymentTypePermissions.Edit)]
		public async Task<PaymentTypeEditDto> CreateOrUpdate(CreateOrUpdatePaymentTypeInput input)
		{

			if (input.PaymentType.Id>0)
			{
				return await Update(input.PaymentType);
			}
			else
			{
				return await Create(input.PaymentType);
			}
		}


		/// <summary>
		/// 新增PaymentType
		/// </summary>
		//[AbpAuthorize(PaymentTypePermissions.Create)]
		protected virtual async Task<PaymentTypeEditDto> Create(PaymentTypeEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <PaymentType>(input);
            var entity=input.MapTo<PaymentType>();
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }
            
            input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
			return input;
		}

		/// <summary>
		/// 编辑PaymentType
		/// </summary>
		//[AbpAuthorize(PaymentTypePermissions.Edit)]
		protected virtual async Task<PaymentTypeEditDto> Update(PaymentTypeEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No & o.Id != input.Id);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }
            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<PaymentTypeEditDto>();
		}



		/// <summary>
		/// 删除PaymentType信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PaymentTypePermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除PaymentType的方法
		/// </summary>
		//[AbpAuthorize(PaymentTypePermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出PaymentType为excel表,等待开发。
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


