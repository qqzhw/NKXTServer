
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


using ICIMS.BusinessManages.Dtos;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages
{
    /// <summary>
    /// Budget应用层服务的接口方法
    ///</summary>
    public interface IBudgetAppService : IApplicationService
    {
        /// <summary>
		/// 获取Budget的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<BudgetListDto>> GetPaged(GetBudgetsInput input);


		/// <summary>
		/// 通过指定id获取BudgetListDto信息
		/// </summary>
		Task<BudgetListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetBudgetForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改Budget的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<BudgetEditDto> CreateOrUpdate(CreateOrUpdateBudgetInput input);


        /// <summary>
        /// 删除Budget信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除Budget
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出Budget为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
