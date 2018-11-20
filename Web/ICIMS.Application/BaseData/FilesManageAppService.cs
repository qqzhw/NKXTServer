
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
using Microsoft.AspNetCore.Http;

namespace ICIMS.BaseData
{
    /// <summary>
    /// FilesManage应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class FilesManageAppService : ICIMSAppServiceBase, IFilesManageAppService
    {
        private readonly IRepository<FilesManage, int> _entityRepository;

        private readonly IFilesManageManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public FilesManageAppService(
        IRepository<FilesManage, int> entityRepository
        ,IFilesManageManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取FilesManage的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(FilesManagePermissions.Query)] 
        public async Task<PagedResultDto<FilesManageListDto>> GetPaged(GetFilesManagesInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<FilesManageListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<FilesManageListDto>>();

			return new PagedResultDto<FilesManageListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取FilesManageListDto信息
		/// </summary>
		//[AbpAuthorize(FilesManagePermissions.Query)] 
		public async Task<FilesManageListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<FilesManageListDto>();
		}

		/// <summary>
		/// 获取编辑 FilesManage
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FilesManagePermissions.Create,FilesManagePermissions.Edit)]
		public async Task<GetFilesManageForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetFilesManageForEditOutput();
FilesManageEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<FilesManageEditDto>();

				//filesManageEditDto = ObjectMapper.Map<List<filesManageEditDto>>(entity);
			}
			else
			{
				editDto = new FilesManageEditDto();
			}

			output.FilesManage = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改FilesManage的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FilesManagePermissions.Create,FilesManagePermissions.Edit)]
		public async Task<FilesManageEditDto> CreateOrUpdate(CreateOrUpdateFilesManageInput input)
		{

			if (input.FilesManage.Id>0)
			{
				return await Update(input.FilesManage);
			}
			else
			{
				return await Create(input.FilesManage);
			}
		}


		/// <summary>
		/// 新增FilesManage
		/// </summary>
		//[AbpAuthorize(FilesManagePermissions.Create)]
		protected virtual async Task<FilesManageEditDto> Create(FilesManageEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <FilesManage>(input);
            var entity=input.MapTo<FilesManage>();

            entity.CreatorUserId = AbpSession.UserId;
			input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
            return input;
		}

		/// <summary>
		/// 编辑FilesManage
		/// </summary>
		//[AbpAuthorize(FilesManagePermissions.Edit)]
		protected virtual async Task<FilesManageEditDto> Update(FilesManageEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);
          
            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<FilesManageEditDto>();
		}



		/// <summary>
		/// 删除FilesManage信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(FilesManagePermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除FilesManage的方法
		/// </summary>
		//[AbpAuthorize(FilesManagePermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}

        public async Task<FilesManageEditDto> UploadFileAsync(IFormCollection formcollection, FilesManageInput model)
        {
            int s=0;
            return null;
        }

        /// <summary>
        /// 导出FilesManage为excel表,等待开发。
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


