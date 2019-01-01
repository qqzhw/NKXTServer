using Abp.Application.Services.Dto;
using ICIMS.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICIMS.BaseData
{
   public  interface IProjectPropsAppService
    {
        Task<PagedResultDto<ProjectPropsListDto>> GetPaged(GetProjectPropsInput input);


        /// <summary>
        /// 通过指定id获取DocumentCategoryListDto信息
        /// </summary>
        Task<ProjectPropsListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetProjectPropsForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改DocumentCategory的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ProjectPropsEditDto> CreateOrUpdate(CreateOrUpdateProjectPropsInput input);


        /// <summary>
        /// 删除DocumentCategory信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除DocumentCategory
        /// </summary>
        Task BatchDelete(List<int> input);

    }
}
