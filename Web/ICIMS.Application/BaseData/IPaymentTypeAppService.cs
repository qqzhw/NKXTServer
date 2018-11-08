
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
    /// PaymentType应用层服务的接口方法
    ///</summary>
    public interface IPaymentTypeAppService : IApplicationService
    {
        /// <summary>
		/// 获取PaymentType的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PaymentTypeListDto>> GetPaged(GetPaymentTypesInput input);


		/// <summary>
		/// 通过指定id获取PaymentTypeListDto信息
		/// </summary>
		Task<PaymentTypeListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPaymentTypeForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改PaymentType的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdatePaymentTypeInput input);


        /// <summary>
        /// 删除PaymentType信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除PaymentType
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出PaymentType为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
