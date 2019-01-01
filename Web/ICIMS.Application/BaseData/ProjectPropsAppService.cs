
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
    /// ProjectProps应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ProjectPropsAppService : ICIMSAppServiceBase, IProjectPropsAppService
    {
        private readonly IRepository<ProjectProps, int> _entityRepository;

        private readonly IProjectPropsManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ProjectPropsAppService(
        IRepository<ProjectProps, int> entityRepository
        , IProjectPropsManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// 获取ProjectProps的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(ProjectPropsPermissions.Query)] 
        public async Task<PagedResultDto<ProjectPropsListDto>> GetPaged(GetProjectPropsInput input)
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

            // var entityListDtos = ObjectMapper.Map<List<ProjectPropsListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<ProjectPropsListDto>>();

            return new PagedResultDto<ProjectPropsListDto>(count, entityListDtos);
        }


        /// <summary>
        /// 通过指定id获取ProjectPropsListDto信息
        /// </summary>
        //[AbpAuthorize(ProjectPropsPermissions.Query)] 
        public async Task<ProjectPropsListDto> GetById(EntityDto<int> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<ProjectPropsListDto>();
        }

        /// <summary>
        /// 获取编辑 ProjectProps
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(ProjectPropsPermissions.Create,ProjectPropsPermissions.Edit)]
        public async Task<GetProjectPropsForEditOutput> GetForEdit(NullableIdDto<int> input)
        {
            var output = new GetProjectPropsForEditOutput();
            ProjectPropsEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _entityRepository.GetAsync(input.Id.Value);

                editDto = entity.MapTo<ProjectPropsEditDto>();

                //ProjectPropsEditDto = ObjectMapper.Map<List<ProjectPropsEditDto>>(entity);
            }
            else
            {
                editDto = new ProjectPropsEditDto();
            }

            output.Item = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改ProjectProps的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(ProjectPropsPermissions.Create,ProjectPropsPermissions.Edit)]
        public async Task<ProjectPropsEditDto> CreateOrUpdate(CreateOrUpdateProjectPropsInput input)
        {

            if (input.Item.Id > 0)
            {
                return await Update(input.Item);
            }
            else
            {
                return await Create(input.Item);
            }
        }


        /// <summary>
        /// 新增ProjectProps
        /// </summary>
        //[AbpAuthorize(ProjectPropsPermissions.Create)]
        protected virtual async Task<ProjectPropsEditDto> Create(ProjectPropsEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <ProjectProps>(input);
            var entity = input.MapTo<ProjectProps>();
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }

            input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
            return input;
        }

        /// <summary>
        /// 编辑ProjectProps
        /// </summary>
        //[AbpAuthorize(ProjectPropsPermissions.Edit)]
        protected virtual async Task<ProjectPropsEditDto> Update(ProjectPropsEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            input.TenantId = AbpSession.TenantId;
            var entity = await _entityRepository.GetAsync(input.Id);
            input.MapTo(entity);
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.No == input.No & o.Id != input.Id);
            if (item != null)
            {
                throw new UserFriendlyException("编号已存在,请重新输入");
            }

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<ProjectPropsEditDto>();
        }



        /// <summary>
        /// 删除ProjectProps信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(ProjectPropsPermissions.Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除ProjectProps的方法
        /// </summary>
        //[AbpAuthorize(ProjectPropsPermissions.BatchDelete)]
        public async Task BatchDelete(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        /// <summary>
        /// 导出ProjectProps为excel表,等待开发。
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


