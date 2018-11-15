
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
    /// FundFrom应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class FundFromAppService : ICIMSAppServiceBase, IFundFromAppService
    {
        private readonly IRepository<FundFrom> _entityRepository;

        private readonly IFundFromManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public FundFromAppService(
        IRepository<FundFrom> entityRepository     
        )
        {
            _entityRepository = entityRepository; 
          //   _entityManager=entityManager;
        }


        /// <summary>
        /// 获取FundFrom的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(FundFromPermissions.Query)] 
        public async Task<PagedResultDto<FundFromListDto>> GetPaged(GetFundFromsInput input)
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

			// var entityListDtos = ObjectMapper.Map<List<FundFromListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<FundFromListDto>>();

			return new PagedResultDto<FundFromListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取FundFromListDto信息
		/// </summary>
		//[AbpAuthorize(FundFromPermissions.Query)] 
		public async Task<FundFromListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<FundFromListDto>();
		}

		/// <summary>
		/// 获取编辑 FundFrom
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FundFromPermissions.Create,FundFromPermissions.Edit)]
		public async Task<GetFundFromForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetFundFromForEditOutput();
FundFromEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<FundFromEditDto>();

				//fundFromEditDto = ObjectMapper.Map<List<fundFromEditDto>>(entity);
			}
			else
			{
				editDto = new FundFromEditDto();
			}

			output.FundFrom = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改FundFrom的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FundFromPermissions.Create,FundFromPermissions.Edit)]
		public async Task<FundFromEditDto> CreateOrUpdate(CreateOrUpdateFundFromInput input)
		{

			if (input.FundFrom.Id>0)
			{
				return await Update(input.FundFrom);
			}
			else
			{
				return await Create(input.FundFrom);
			}
		}


		/// <summary>
		/// 新增FundFrom
		/// </summary>
		//[AbpAuthorize(FundFromPermissions.Create)]
		protected virtual async Task<FundFromEditDto> Create(FundFromEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <FundFrom>(input);
            var entity=input.MapTo<FundFrom>();

            var item = _entityRepository.FirstOrDefaultAsync(o => o.No == input.No);
            if (item!=null)
            {
                throw new AbpException("编号已存在,请重新输入");
            }
			int id = await _entityRepository.InsertAndGetIdAsync(entity);
            input.Id = id;
			return input;
		}

		/// <summary>
		/// 编辑FundFrom
		/// </summary>
		//[AbpAuthorize(FundFromPermissions.Edit)]
		protected virtual async Task<FundFromEditDto> Update(FundFromEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);
            var item = _entityRepository.FirstOrDefaultAsync(o => o.No == input.No & o.Id != input.Id);
            if (item != null)
            {
                throw new AbpException("编号已存在,请重新输入");
            }
            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<FundFromEditDto>();
		}



		/// <summary>
		/// 删除FundFrom信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FundFromPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除FundFrom的方法
		/// </summary>
		//[AbpAuthorize(FundFromPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出FundFrom为excel表,等待开发。
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


