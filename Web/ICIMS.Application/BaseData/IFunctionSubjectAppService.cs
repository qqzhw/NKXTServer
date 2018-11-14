
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
    /// FunctionSubject应用层服务的接口方法
    ///</summary>
    public interface IFunctionSubjectAppService : IApplicationService
    {
        /// <summary>
		/// 获取FunctionSubject的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<FunctionSubjectListDto>> GetPaged(GetFunctionSubjectsInput input);


		/// <summary>
		/// 通过指定id获取FunctionSubjectListDto信息
		/// </summary>
		Task<FunctionSubjectListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetFunctionSubjectForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改FunctionSubject的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FunctionSubjectEditDto> CreateOrUpdate(CreateOrUpdateFunctionSubjectInput input);


        /// <summary>
        /// 删除FunctionSubject信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除FunctionSubject
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出FunctionSubject为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
