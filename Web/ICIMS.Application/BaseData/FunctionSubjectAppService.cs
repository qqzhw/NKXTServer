
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


namespace ICIMS.BaseData
{
    /// <summary>
    /// FunctionSubject应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class FunctionSubjectAppService : ICIMSAppServiceBase, IFunctionSubjectAppService
    {
        private readonly IRepository<FunctionSubject, int> _entityRepository;

        private readonly IFunctionSubjectManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public FunctionSubjectAppService(
        IRepository<FunctionSubject, int> entityRepository
        ,IFunctionSubjectManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取FunctionSubject的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(FunctionSubjectPermissions.Query)] 
        public async Task<PagedResultDto<FunctionSubjectListDto>> GetPaged(GetFunctionSubjectsInput input)
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

			// var entityListDtos = ObjectMapper.Map<List<FunctionSubjectListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<FunctionSubjectListDto>>();

			return new PagedResultDto<FunctionSubjectListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取FunctionSubjectListDto信息
		/// </summary>
		//[AbpAuthorize(FunctionSubjectPermissions.Query)] 
		public async Task<FunctionSubjectListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<FunctionSubjectListDto>();
		}

		/// <summary>
		/// 获取编辑 FunctionSubject
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FunctionSubjectPermissions.Create,FunctionSubjectPermissions.Edit)]
		public async Task<GetFunctionSubjectForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetFunctionSubjectForEditOutput();
FunctionSubjectEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<FunctionSubjectEditDto>();

				//functionSubjectEditDto = ObjectMapper.Map<List<functionSubjectEditDto>>(entity);
			}
			else
			{
				editDto = new FunctionSubjectEditDto();
			}

			output.FunctionSubject = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改FunctionSubject的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FunctionSubjectPermissions.Create,FunctionSubjectPermissions.Edit)]
		public async Task<FunctionSubjectEditDto> CreateOrUpdate(CreateOrUpdateFunctionSubjectInput input)
		{

			if (input.FunctionSubject.Id.HasValue&input.FunctionSubject.Id>0)
			{
				return await Update(input.FunctionSubject);
			}
			else
			{
				return await Create(input.FunctionSubject);
			}
		}


		/// <summary>
		/// 新增FunctionSubject
		/// </summary>
		//[AbpAuthorize(FunctionSubjectPermissions.Create)]
		protected virtual async Task<FunctionSubjectEditDto> Create(FunctionSubjectEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <FunctionSubject>(input);
            var entity=input.MapTo<FunctionSubject>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<FunctionSubjectEditDto>();
		}

		/// <summary>
		/// 编辑FunctionSubject
		/// </summary>
		//[AbpAuthorize(FunctionSubjectPermissions.Edit)]
		protected virtual async Task<FunctionSubjectEditDto> Update(FunctionSubjectEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<FunctionSubjectEditDto>();
		}



		/// <summary>
		/// 删除FunctionSubject信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FunctionSubjectPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除FunctionSubject的方法
		/// </summary>
		//[AbpAuthorize(FunctionSubjectPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出FunctionSubject为excel表,等待开发。
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


