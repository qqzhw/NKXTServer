
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
    /// Vendor应用层服务的接口方法
    ///</summary>
    public interface IVendorAppService : IApplicationService
    {
        /// <summary>
		/// 获取Vendor的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<VendorListDto>> GetPaged(GetVendorsInput input);


		/// <summary>
		/// 通过指定id获取VendorListDto信息
		/// </summary>
		Task<VendorListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetVendorForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改Vendor的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<VendorEditDto> CreateOrUpdate(CreateOrUpdateVendorInput input);


        /// <summary>
        /// 删除Vendor信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除Vendor
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出Vendor为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
