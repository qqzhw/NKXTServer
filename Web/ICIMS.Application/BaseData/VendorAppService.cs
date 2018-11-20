
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
    /// Vendor应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class VendorAppService : ICIMSAppServiceBase, IVendorAppService
    {
        private readonly IRepository<Vendor, int> _entityRepository;

        private readonly IVendorManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public VendorAppService(
        IRepository<Vendor, int> entityRepository
        ,IVendorManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Vendor的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(VendorPermissions.Query)] 
        public async Task<PagedResultDto<VendorListDto>> GetPaged(GetVendorsInput input)
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

			// var entityListDtos = ObjectMapper.Map<List<VendorListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<VendorListDto>>();

			return new PagedResultDto<VendorListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取VendorListDto信息
		/// </summary>
		//[AbpAuthorize(VendorPermissions.Query)] 
		public async Task<VendorListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<VendorListDto>();
		}

		/// <summary>
		/// 获取编辑 Vendor
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(VendorPermissions.Create,VendorPermissions.Edit)]
		public async Task<GetVendorForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetVendorForEditOutput();
VendorEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<VendorEditDto>();

				//vendorEditDto = ObjectMapper.Map<List<vendorEditDto>>(entity);
			}
			else
			{
				editDto = new VendorEditDto();
			}

			output.Vendor = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Vendor的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(VendorPermissions.Create,VendorPermissions.Edit)]
		public async Task<VendorEditDto> CreateOrUpdate(CreateOrUpdateVendorInput input)
		{

			if (input.Vendor.Id>0)
			{
				return await Update(input.Vendor);
			}
			else
			{
				return await Create(input.Vendor);
			}
		}


		/// <summary>
		/// 新增Vendor
		/// </summary>
		//[AbpAuthorize(VendorPermissions.Create)]
		protected virtual async Task<VendorEditDto> Create(VendorEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <Vendor>(input);
            var entity=input.MapTo<Vendor>();

            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }
            entity.CreatorUserId = AbpSession.UserId;
            entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<VendorEditDto>();
		}

		/// <summary>
		/// 编辑Vendor
		/// </summary>
		//[AbpAuthorize(VendorPermissions.Edit)]
		protected virtual async Task<VendorEditDto> Update(VendorEditDto input)
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
            return entity.MapTo<VendorEditDto>();

        }



		/// <summary>
		/// 删除Vendor信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(VendorPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Vendor的方法
		/// </summary>
		//[AbpAuthorize(VendorPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出Vendor为excel表,等待开发。
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


