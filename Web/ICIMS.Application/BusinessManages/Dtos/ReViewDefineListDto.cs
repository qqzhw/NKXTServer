

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;
using Abp.Domain.Entities;
using ICIMS.Authorization.Users;

namespace ICIMS.BusinessManages.Dtos
{
    public class ReViewDefineListDto : FullAuditedEntityDto,IMayHaveTenant 
    {

        
		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		[Required(ErrorMessage="Status不能为空")]
		public int Status { get; set; }



		/// <summary>
		/// ItemDefineId
		/// </summary>
		public int ItemDefineId { get; set; }



		/// <summary>
		/// ReViewNo
		/// </summary>
		[Required(ErrorMessage="ReViewNo不能为空")]
		public string ReViewNo { get; set; }



		/// <summary>
		/// ReViewName
		/// </summary>
		[Required(ErrorMessage="ReViewName不能为空")]
		public string ReViewName { get; set; }



		/// <summary>
		/// ReViewDocNo
		/// </summary>
		public string ReViewDocNo { get; set; }



		/// <summary>
		/// ReViewAmount
		/// </summary>
		public decimal ReViewAmount { get; set; }



		/// <summary>
		/// Remark
		/// </summary>
		public string Remark { get; set; }



		/// <summary>
		/// AuditDate
		/// </summary>
		public DateTime? AuditDate { get; set; }



		/// <summary>
		/// AuditUserId
		/// </summary>
		public int? AuditUserId { get; set; }



		/// <summary>
		/// AuditUser
		/// </summary>
		public User AuditUser { get; set; }



		/// <summary>
		/// SysGuid
		/// </summary>
		[Required(ErrorMessage="SysGuid不能为空")]
		public string SysGuid { get; set; }




    }
}