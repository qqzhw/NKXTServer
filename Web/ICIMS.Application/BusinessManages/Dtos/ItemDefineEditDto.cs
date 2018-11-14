
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.Authorization.Users;
using ICIMS.BusinessManages;
using ICIMS.Users.Dto;

namespace  ICIMS.BusinessManages.Dtos
{
    public class ItemDefineEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// SysGuid
		/// </summary>		
		public string SysGuid { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		[Required(ErrorMessage="Status不能为空")]
		public int Status { get; set; }



		/// <summary>
		/// UnitId
		/// </summary>
		[Required(ErrorMessage="UnitId不能为空")]
		public int UnitId { get; set; }



		/// <summary>
		/// BudgetId
		/// </summary>
		[Required(ErrorMessage="BudgetId不能为空")]
		public int? BudgetId { get; set; }



		/// <summary>
		/// ItemDocNo
		/// </summary>
		public string ItemDocNo { get; set; }



		/// <summary>
		/// DefineDate
		/// </summary>
		public DateTime DefineDate { get; set; }



		/// <summary>
		/// ItemNo
		/// </summary>
		[Required(ErrorMessage="ItemNo不能为空")]
		public string ItemNo { get; set; }



		/// <summary>
		/// ItemName
		/// </summary>
		[Required(ErrorMessage="ItemName不能为空")]
		public string ItemName { get; set; }



		 

        public int ItemCategoryId { get; set; }

        /// <summary>
        /// DefineAmount
        /// </summary>
        public decimal DefineAmount { get; set; }



		/// <summary>
		/// ItemAddress
		/// </summary>
		public string ItemAddress { get; set; }



		/// <summary>
		/// ItemDescription
		/// </summary>
		public string ItemDescription { get; set; }



		/// <summary>
		/// Remark
		/// </summary>
		public string Remark { get; set; }



		/// <summary>
		/// IsFinal
		/// </summary>
		public bool IsFinal { get; set; }



		/// <summary>
		/// IsAudit
		/// </summary>
		public bool IsAudit { get; set; }



		/// <summary>
		/// AuditDate
		/// </summary>
		public DateTime AuditDate { get; set; }



		/// <summary>
		/// AuditUserId
		/// </summary>
		public int? AuditUserId { get; set; }



		/// <summary>
		/// AuditUser
		/// </summary>
		public UserDto AuditUser { get; set; }  

    }
}