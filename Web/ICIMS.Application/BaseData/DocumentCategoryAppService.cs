
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
    /// DocumentCategory应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class DocumentCategoryAppService : ICIMSAppServiceBase, IDocumentCategoryAppService
    {
        private readonly IRepository<DocumentCategory, int> _entityRepository;

        private readonly IDocumentCategoryManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public DocumentCategoryAppService(
        IRepository<DocumentCategory, int> entityRepository
        ,IDocumentCategoryManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取DocumentCategory的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(DocumentCategoryPermissions.Query)] 
        public async Task<PagedResultDto<DocumentCategoryListDto>> GetPaged(GetDocumentCategorysInput input)
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

			// var entityListDtos = ObjectMapper.Map<List<DocumentCategoryListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<DocumentCategoryListDto>>();

			return new PagedResultDto<DocumentCategoryListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取DocumentCategoryListDto信息
		/// </summary>
		//[AbpAuthorize(DocumentCategoryPermissions.Query)] 
		public async Task<DocumentCategoryListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<DocumentCategoryListDto>();
		}

		/// <summary>
		/// 获取编辑 DocumentCategory
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(DocumentCategoryPermissions.Create,DocumentCategoryPermissions.Edit)]
		public async Task<GetDocumentCategoryForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetDocumentCategoryForEditOutput();
DocumentCategoryEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<DocumentCategoryEditDto>();

				//documentCategoryEditDto = ObjectMapper.Map<List<documentCategoryEditDto>>(entity);
			}
			else
			{
				editDto = new DocumentCategoryEditDto();
			}

			output.DocumentCategory = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改DocumentCategory的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(DocumentCategoryPermissions.Create,DocumentCategoryPermissions.Edit)]
		public async Task<DocumentCategoryEditDto> CreateOrUpdate(CreateOrUpdateDocumentCategoryInput input)
		{

			if (input.DocumentCategory.Id>0)
			{
				return await Update(input.DocumentCategory);
			}
			else
			{
				return await Create(input.DocumentCategory);
			}
		}


		/// <summary>
		/// 新增DocumentCategory
		/// </summary>
		//[AbpAuthorize(DocumentCategoryPermissions.Create)]
		protected virtual async Task<DocumentCategoryEditDto> Create(DocumentCategoryEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <DocumentCategory>(input);
            var entity=input.MapTo<DocumentCategory>();
            var item = _entityRepository.FirstOrDefaultAsync(o => o.No == input.No);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }

            input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
            return input;
		}

		/// <summary>
		/// 编辑DocumentCategory
		/// </summary>
		//[AbpAuthorize(DocumentCategoryPermissions.Edit)]
		protected virtual async  Task<DocumentCategoryEditDto> Update(DocumentCategoryEditDto input)
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
            return entity.MapTo<DocumentCategoryEditDto>();
        }



		/// <summary>
		/// 删除DocumentCategory信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(DocumentCategoryPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除DocumentCategory的方法
		/// </summary>
		//[AbpAuthorize(DocumentCategoryPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出DocumentCategory为excel表,等待开发。
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


