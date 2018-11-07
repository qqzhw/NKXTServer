
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
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using ICIMS.BaseData.Dtos;
using ICIMS.BaseData;

namespace ICIMS.BaseData
{
    /// <summary>
    /// DocumentCategory应用层服务的接口方法
    ///</summary>
    public interface IDocumentCategoryAppService : IApplicationService
    {
        /// <summary>
		/// 获取DocumentCategory的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<DocumentCategoryListDto>> GetPaged(GetDocumentCategorysInput input);


		/// <summary>
		/// 通过指定id获取DocumentCategoryListDto信息
		/// </summary>
		Task<DocumentCategoryListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetDocumentCategoryForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改DocumentCategory的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateDocumentCategoryInput input);


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


		/// <summary>
        /// 导出DocumentCategory为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
