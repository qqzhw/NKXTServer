
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
    /// PayAudit应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class PayAuditAppService : ICIMSAppServiceBase, IPayAuditAppService
    {
        private readonly IRepository<PayAudit, int> _entityRepository;
        private readonly IRepository<PayAuditDetail, int> _entityDetailRepository;
        private readonly IRepository<BusinessAudit, int> _entityAuditRepository;
        private readonly IRepository<BusinessAuditStatus, int> _entityAuditStatusRepository;
        private readonly IPayAuditManager _entityManager;
        private readonly IRepository<UserManageUnit, int> _entitymanageunitRepository;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public PayAuditAppService(
        IRepository<PayAudit, int> entityRepository, IRepository<PayAuditDetail, int> entityDetailRepository, IRepository<BusinessAudit, int> entityauditRepository, IRepository<BusinessAuditStatus, int> entityauditstatusRepository,
      IRepository<UserManageUnit, int> entitymanageunitRepository
        , IPayAuditManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
            _entityDetailRepository = entityDetailRepository;
            _entityAuditRepository = entityauditRepository;
            _entityAuditStatusRepository = entityauditstatusRepository;
            _entitymanageunitRepository = entitymanageunitRepository;
        }


        /// <summary>
        /// 获取PayAudit的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		//[AbpAuthorize(PayAuditPermissions.Query)] 
        public async Task<PagedResultDto<PayAuditListDto>> GetPaged(GetPayAuditsInput input)
		{

		    var query =from o  in _entityRepository.GetAllIncluding(o=>o.Contract).Include(o=>o.Contract.ItemDefine).Include(o=>o.ItemDefine.Unit).Include(o=>o.Contract.Vendor).Include(o=>o.AuditUser).Include(o=>o.CreatorUser)
                 join u in _entitymanageunitRepository.GetAll().Where(o => o.UserId == AbpSession.UserId) on o.UnitId equals u.UnitId
                       select new PayAuditListDto()
                       {
                           PayAudit = o.MapTo<PayAuditEditDto>(),
                           AccountName = o.Contract.Vendor.AccountName,
                           AuditUserName = o.AuditUser.Name,
                           ContractAmount = o.Contract.ContractAmount,
                           ContractName = o.Contract.ContractName,
                           CreationTime = o.CreationTime,
                           CreatorUserId = o.CreatorUserId,
                           CreatorUserName = o.CreatorUser.Name,
                           DefineAmount = o.ItemDefine.DefineAmount,
                           Id = o.Id,
                           IsDeleted = o.IsDeleted,
                           ItemDefineName = o.ItemDefine.ItemName,
                           ItemNo = o.ItemDefine.ItemNo,
                           LinkPhone = o.Contract.Vendor.LinkPhone,
                           OpenBank = o.Contract.Vendor.OpenBank,
                           PaymentTypeName = o.PaymentType.Name,
                           UnitName = o.ItemDefine.Unit.DisplayName,
                           VendorName = o.Contract.Vendor.Name
                       };
            // TODO:根据传入的参数添加过滤条件
            if (input.Status.HasValue)
            {
                query = query.Where(o => o.PayAudit.Status == input.Status);
            }

            var count = await query.CountAsync();

			var entityList = await query
					.OrderByDescending(o=>o.Id).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<PayAuditListDto>>(entityList);
			//var entityListDtos =entityList.MapTo<List<PayAuditListDto>>();

			return new PagedResultDto<PayAuditListDto>(count, entityList);
		}


		/// <summary>
		/// 通过指定id获取PayAuditListDto信息
		/// </summary>
		//[AbpAuthorize(PayAuditPermissions.Query)] 
		public async Task<PayAuditListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<PayAuditListDto>();
		}

		/// <summary>
		/// 获取编辑 PayAudit
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditPermissions.Create,PayAuditPermissions.Edit)]
		public async Task<GetPayAuditForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetPayAuditForEditOutput();
PayAuditEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<PayAuditEditDto>();

				//payAuditEditDto = ObjectMapper.Map<List<payAuditEditDto>>(entity);
			}
			else
			{
				editDto = new PayAuditEditDto();
			}

			output.PayAudit = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改PayAudit的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditPermissions.Create,PayAuditPermissions.Edit)]
		public async Task<PayAuditEditDto> CreateOrUpdate(CreateOrUpdatePayAuditInput input)
		{

			if (input.PayAudit.Id>0)
			{
			   return 	await Update(input.PayAudit);
			}
			else
			{
				return await Create(input.PayAudit);
			}
		}


		/// <summary>
		/// 新增PayAudit
		/// </summary>
		//[AbpAuthorize(PayAuditPermissions.Create)]
		protected virtual async Task<PayAuditEditDto> Create(PayAuditEditDto input)
		{
            //TODO:新增前的逻辑判断，是否允许新增
            input.TenantId = AbpSession.TenantId;
            // var entity = ObjectMapper.Map <PayAudit>(input);
            var entity=input.MapTo<PayAudit>();
            var item = await _entityRepository.FirstOrDefaultAsync(o => o.PaymentName == input.PaymentName);
            if (item != null)
            {
                throw new UserFriendlyException("已存在相同名称,请重新输入");
            }
            entity.TenantId = AbpSession.TenantId;
            entity.SysGuid = Guid.NewGuid().ToString();
            entity.PaymentNo = GenerateId(input.ItemDefineId);
            entity.CreatorUserId = AbpSession.UserId;
            
            input.Id = await _entityRepository.InsertAndGetIdAsync(entity);
            foreach (var detail in input.PayAuditDetails)
            {
                var payDetail = detail.MapTo<PayAuditDetail>();
                payDetail.PayAuditId = entity.Id;
                payDetail.TenantId = AbpSession.TenantId;
               payDetail.Id= await _entityDetailRepository.InsertAndGetIdAsync(payDetail);
            }
            input.PaymentNo = entity.PaymentNo;

            var audit = _entityAuditRepository.GetAll().Where(o => o.BusinessTypeName == "支付审核");
            foreach (var businessaudit in audit)
            {
                var auditStatus = new BusinessAuditStatus()
                {
                    TenantId = AbpSession.TenantId,
                    BusinessAuditId = businessaudit.Id,
                    BusinessTypeName = businessaudit.BusinessTypeName,
                    DisplayOrder = businessaudit.DisplayOrder,
                    EntityId = input.Id,
                };
                _entityAuditStatusRepository.Insert(auditStatus);
            }
            return input;
		}
        private string GenerateId(int itemdefineId)
        {
            var query = _entityRepository.GetAllIncluding(o => o.ItemDefine).Where(o => o.ItemDefineId == itemdefineId).Select(o => new { o.ItemDefineId, o.PaymentNo, o.ItemDefine.ItemNo });

            var findnumber = query.Count();
                findnumber += 1;
            var id =findnumber.ToString().PadLeft(3, '0');
            var no = $"{query.FirstOrDefault()?.ItemNo}_ZF{id}";
          //  var id = DateTime.Now.ToString("yyyyMMdd000");
            //var no = $"ZF{Convert.ToInt64(id) + findnumber}";
            return no;
        }
        /// <summary>
        /// 编辑PayAudit
        /// </summary>
        //[AbpAuthorize(PayAuditPermissions.Edit)]
        protected virtual async Task<PayAuditEditDto> Update(PayAuditEditDto input)
		{
            //TODO:更新前的逻辑判断，是否允许更新
            input.TenantId = AbpSession.TenantId;
            input.TenantId = AbpSession.TenantId;
            if (input.Status == 3)
            {
                input.AuditUserId = AbpSession.UserId;
                input.AuditDate = DateTime.Now;
            }
            var entity = await _entityRepository.GetAsync(input.Id);
			input.MapTo(entity);
            entity.LastModifierUserId = AbpSession.UserId;
            entity.LastModificationTime = DateTime.Now;
			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
            return entity.MapTo<PayAuditEditDto>();
		}



		/// <summary>
		/// 删除PayAudit信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		//[AbpAuthorize(PayAuditPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除PayAudit的方法
		/// </summary>
		//[AbpAuthorize(PayAuditPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}
       
        public async Task<List<PayAuditEditDto>> GetSearchPayCount(EntityDto<int> input)
        {
            var query =_entityRepository.GetAll().Where(o=>o.ItemDefineId==input.Id);

            var list = await query.ToListAsync();
            return list.MapTo<List<PayAuditEditDto>>();
        }

        /// <summary>
        /// 导出PayAudit为excel表,等待开发。
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


