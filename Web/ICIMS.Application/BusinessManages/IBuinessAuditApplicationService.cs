
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
    /// BuinessAudit应用层服务的接口方法
    ///</summary>
    public interface IBuinessAuditAppService : IApplicationService
    {
        /// <summary>
		/// 获取BuinessAudit的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<BuinessAuditListDto>> GetPaged(GetBuinessAuditsInput input);


		/// <summary>
		/// 通过指定id获取BuinessAuditListDto信息
		/// </summary>
		Task<BuinessAuditListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetBuinessAuditForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改BuinessAudit的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateBuinessAuditInput input);


        /// <summary>
        /// 删除BuinessAudit信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除BuinessAudit
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出BuinessAudit为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
