
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.Authorization.Users;
using ICIMS.BusinessManages;

namespace  ICIMS.BusinessManages.Dtos
{
    public class PayAuditEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }         


        
		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// SysGuid
		/// </summary>
		[Required(ErrorMessage="SysGuid不能为空")]
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
		public int? UnitId { get; set; }



		/// <summary>
		/// ContrctId
		/// </summary>
		[Required(ErrorMessage="ContrctId不能为空")]
		public int ContrctId { get; set; }



		/// <summary>
		/// ItemDefineId
		/// </summary>
		public int ItemDefineId { get; set; }



		/// <summary>
		/// PaymentTypeId
		/// </summary>
		public int PaymentTypeId { get; set; }



		/// <summary>
		/// PaymentNo
		/// </summary>
		public string PaymentNo { get; set; }



		/// <summary>
		/// PaymentName
		/// </summary>
		public string PaymentName { get; set; }



		/// <summary>
		/// PayAmount
		/// </summary>
		public decimal PayAmount { get; set; }



		/// <summary>
		/// PaymentPer
		/// </summary>
		public int PaymentPer { get; set; }



		/// <summary>
		/// PaymentCount
		/// </summary>
		public int PaymentCount { get; set; }



		/// <summary>
		/// ItemYsTotalAmount
		/// </summary>
		public decimal? ItemYsTotalAmount { get; set; }



		/// <summary>
		/// ItemTotalAmount
		/// </summary>
		public decimal ItemTotalAmount { get; set; }



		/// <summary>
		/// ContractTotalAmount
		/// </summary>
		public decimal ContractTotalAmount { get; set; }



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




    }
}