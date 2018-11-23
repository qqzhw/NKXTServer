
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using ICIMS.BusinessManages;
using ICIMS.BusinessManages.Dtos;
using ICIMS.BusinessManages.DomainService;
using ICIMS.BusinessManages.Authorization;


namespace ICIMS.BusinessManages
{
    /// <summary>
    /// ReViewDefine应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ReViewDefineAppService : ICIMSAppServiceBase, IReViewDefineAppService
    {
        private readonly IRepository<ReViewDefine, int> _entityRepository;

        private readonly IReViewDefineManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ReViewDefineAppService(
        IRepository<ReViewDefine, int> entityRepository
        ,IReViewDefineManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取ReViewDefine的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(ReViewDefinePermissions.Query)] 
        public async Task<PagedResultDto<ReViewDefineListDto>> GetPaged(GetReViewDefinesInput input)
		{

		    var query = _entityRepository.GetAllIncluding(o=>o.ItemDefine).Include(o=>o.ItemDefine.Unit).Include(o=>o.AuditUser).Include(o=>o.CreatorUser)
                .Select(o=>new ReViewDefineListDto
                {
                    Entity = o.MapTo<ReViewDefineEditDto>(),
                    AuditUserName = o.AuditUser.Name,
                    Id = o.Id,
                    ItemDefineName = o.ItemDefine.ItemName,
                    ItemNo = o.ItemDefine.ItemNo,
                    CreatorUserName = o.CreatorUser.Name,
                    UnitName = o.ItemDefine.Unit.DisplayName,
                    CreationTime=o.CreationTime,
                    CreatorUserId=o.CreatorUserId,
                    IsDeleted=o.IsDeleted                   
                });
            // TODO:根据传入的参数添加过滤条件
            if (!string.IsNullOrEmpty(input.No))
            {
                query = query.Where(o => o.Entity.ReViewNo.Contains(input.No));
            }
            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.Where(o => o.Entity.ReViewName.Contains(input.Name));
            }
            var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ReViewDefineListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<ReViewDefineListDto>>();

			return new PagedResultDto<ReViewDefineListDto>(count, entityList);
		}


		/// <summary>
		/// 通过指定id获取ReViewDefineListDto信息
		/// </summary>
		//[AbpAuthorize(ReViewDefinePermissions.Query)] 
		public async Task<ReViewDefineListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ReViewDefineListDto>();
		}

		/// <summary>
		/// 获取编辑 ReViewDefine
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ReViewDefinePermissions.Create,ReViewDefinePermissions.Edit)]
		public async Task<GetReViewDefineForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetReViewDefineForEditOutput();
ReViewDefineEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ReViewDefineEditDto>();

				//reViewDefineEditDto = ObjectMapper.Map<List<reViewDefineEditDto>>(entity);
			}
			else
			{
				editDto = new ReViewDefineEditDto();
			}

			output.ReViewDefine = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改ReViewDefine的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ReViewDefinePermissions.Create,ReViewDefinePermissions.Edit)]
		public async Task<ReViewDefineEditDto> CreateOrUpdate(CreateOrUpdateReViewDefineInput input)
		{

			if (input.ReViewDefine.Id>0)
			{
				return await Update(input.ReViewDefine);
			}
			else
			{
				return await Create(input.ReViewDefine);
			}
		}


		/// <summary>
		/// 新增ReViewDefine
		/// </summary>
		//[AbpAuthorize(ReViewDefinePermissions.Create)]
		protected virtual async Task<ReViewDefineEditDto> Create(ReViewDefineEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            
            // var entity = ObjectMapper.Map <ReViewDefine>(input);
            var entity=input.MapTo<ReViewDefine>();
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.ReViewName == input.ReViewName);
            if (item != null)
            {
                throw new UserFriendlyException("已存在相同名称,请重新输入");
            }
            entity.CreatorUserId = AbpSession.UserId;
			input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
			return input;
		}
        private string GenerateId()
        {
            var findnumber = _entityRepository.LongCount(o => o.CreationTime.Date == DateTime.Now.Date);

            findnumber += 1;

            var id = DateTime.Now.ToString("yyyyMMdd000");
            var no = $"PS{Convert.ToInt64(id) + findnumber}";
            return no;
        }
        /// <summary>
        /// 编辑ReViewDefine
        /// </summary>
        //[AbpAuthorize(ReViewDefinePermissions.Edit)]
        protected virtual async Task<ReViewDefineEditDto> Update(ReViewDefineEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<ReViewDefineEditDto>();
		}



		/// <summary>
		/// 删除ReViewDefine信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(ReViewDefinePermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除ReViewDefine的方法
		/// </summary>
		//[AbpAuthorize(ReViewDefinePermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出ReViewDefine为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


