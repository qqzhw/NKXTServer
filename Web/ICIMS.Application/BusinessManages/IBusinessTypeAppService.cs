
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
 
 
using ICIMS.BussinesManages.Dtos;

namespace ICIMS.BussinesManages
{
    /// <summary>
    /// BusinessType应用层服务的接口方法
    ///</summary>
    public interface IBusinessTypeAppService : IApplicationService
    {
        /// <summary>
		/// 获取BusinessType的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<BusinessTypeListDto>> GetPaged(GetBusinessTypesInput input);


		/// <summary>
		/// 通过指定id获取BusinessTypeListDto信息
		/// </summary>
		Task<BusinessTypeListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetBusinessTypeForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改BusinessType的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateBusinessTypeInput input);


        /// <summary>
        /// 删除BusinessType信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除BusinessType
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出BusinessType为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
