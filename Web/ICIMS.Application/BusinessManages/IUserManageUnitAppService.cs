
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
    /// UserManageUnit应用层服务的接口方法
    ///</summary>
    public interface IUserManageUnitAppService : IApplicationService
    {
        /// <summary>
		/// 获取UserManageUnit的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<UserManageUnitListDto>> GetPaged(GetUserManageUnitsInput input);


		/// <summary>
		/// 通过指定id获取UserManageUnitListDto信息
		/// </summary>
		Task<UserManageUnitListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetUserManageUnitForEditOutput> GetForEdit(EntityDto<int> input);


        /// <summary>
        /// 添加或者修改UserManageUnit的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserManageUnitEditDto> CreateOrUpdate(CreateOrUpdateUserManageUnitInput input);


        /// <summary>
        /// 删除UserManageUnit信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除UserManageUnit
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出UserManageUnit为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
