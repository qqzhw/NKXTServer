
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
    /// FilesManage应用层服务的接口方法
    ///</summary>
    public interface IFilesManageAppService : IApplicationService
    {
        /// <summary>
		/// 获取FilesManage的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<FilesManageListDto>> GetPaged(GetFilesManagesInput input);


		/// <summary>
		/// 通过指定id获取FilesManageListDto信息
		/// </summary>
		Task<FilesManageListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetFilesManageForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改FilesManage的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateFilesManageInput input);


        /// <summary>
        /// 删除FilesManage信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除FilesManage
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出FilesManage为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
