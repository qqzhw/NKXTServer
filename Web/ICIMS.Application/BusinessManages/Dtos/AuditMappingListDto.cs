

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;
using Abp.Domain.Entities;

namespace ICIMS.BusinessManages.Dtos
{
    public class AuditMappingListDto : EntityDto,IMayHaveTenant,ICreationAudited 
    {

        
		/// <summary>
		/// DisplayOrder
		/// </summary>
		public int DisplayOrder { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// BuinessAuditId
		/// </summary> 
		public int BusinessAuditId { get; set; }



		/// <summary>
		/// BuinessTypeId
		/// </summary>
		[Required(ErrorMessage="BusinessTypeId不能为空")]
		public int BusinessTypeId { get; set; }
        public string BusinessTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

     /// <summary>
     /// ItemId
     /// </summary>
       [Required(ErrorMessage="ItemId不能为空")]
		public int ItemId { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		public int Status { get; set; }



		/// <summary>
		/// AuditOpinion
		/// </summary>
		public string AuditOpinion { get; set; }



		/// <summary>
		/// CreatorUserId
		/// </summary>
		public long? CreatorUserId { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }



		/// <summary>
		/// AuditTime
		/// </summary>
		public DateTime? AuditTime { get; set; }

        public string  AuditUserName { get;set; }

       
    }
}