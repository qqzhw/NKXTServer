
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
    /// ReViewDefine应用层服务的接口方法
    ///</summary>
    public interface IReViewDefineAppService : IApplicationService
    {
        /// <summary>
		/// 获取ReViewDefine的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ReViewDefineListDto>> GetPaged(GetReViewDefinesInput input);


		/// <summary>
		/// 通过指定id获取ReViewDefineListDto信息
		/// </summary>
		Task<ReViewDefineListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetReViewDefineForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改ReViewDefine的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ReViewDefineEditDto> CreateOrUpdate(CreateOrUpdateReViewDefineInput input);


        /// <summary>
        /// 删除ReViewDefine信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除ReViewDefine
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出ReViewDefine为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
