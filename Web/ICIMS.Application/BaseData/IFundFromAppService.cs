
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
    /// FundFrom应用层服务的接口方法
    ///</summary>
    public interface IFundFromAppService : IApplicationService
    {
        /// <summary>
		/// 获取FundFrom的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<FundFromListDto>> GetPaged(GetFundFromsInput input);


		/// <summary>
		/// 通过指定id获取FundFromListDto信息
		/// </summary>
		Task<FundFromListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetFundFromForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改FundFrom的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateFundFromInput input);


        /// <summary>
        /// 删除FundFrom信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除FundFrom
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出FundFrom为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
