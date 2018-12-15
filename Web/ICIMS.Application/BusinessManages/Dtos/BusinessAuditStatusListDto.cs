

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;
using Abp.Domain.Entities;

namespace ICIMS.BusinessManages.Dtos
{
    public class BusinessAuditStatusListDto : EntityDto,IMayHaveTenant 
    {

        
		/// <summary>
		/// EntityId
		/// </summary>
		[Required(ErrorMessage="EntityId不能为空")]
		public int EntityId { get; set; }



		/// <summary>
		/// BusinessTypeName
		/// </summary>
		public string BusinessTypeName { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		public int Status { get; set; }



		/// <summary>
		/// BusinessAuditId
		/// </summary>
		[Required(ErrorMessage="BusinessAuditId不能为空")]
		public int BusinessAuditId { get; set; }



		/// <summary>
		/// BusinessAudit
		/// </summary>
		public BusinessAudit BusinessAudit { get; set; }



		/// <summary>
		/// DisplayOrder
		/// </summary>
		public int DisplayOrder { get; set; }
        public int? TenantId { get ; set; }
        public  int RoleId { get; set; }
    }
}