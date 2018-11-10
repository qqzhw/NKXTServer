
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.Authorization.Users;
using ICIMS.BaseData;
using ICIMS.BusinessManages;

namespace  ICIMS.BusinessManages.Dtos
{
    public class ContractEditDto
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
		[Required(ErrorMessage="SysGuid不能为空")]
		public string SysGuid { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		[Required(ErrorMessage="Status不能为空")]
		public int Status { get; set; }



		/// <summary>
		/// ItemDefineId
		/// </summary>
		[Required(ErrorMessage="ItemDefineId不能为空")]
		public int ItemDefineId { get; set; }



		/// <summary>
		/// UintId
		/// </summary>
		[Required(ErrorMessage="UintId不能为空")]
		public int UintId { get; set; }



		/// <summary>
		/// ContractTypeId
		/// </summary>
		[Required(ErrorMessage="ContractTypeId不能为空")]
		public int ContractTypeId { get; set; }



		/// <summary>
		/// ContractType
		/// </summary>
		[Required(ErrorMessage="ContractType不能为空")]
		public ContractCategory ContractType { get; set; }



		/// <summary>
		/// BeginTime
		/// </summary>
		[Required(ErrorMessage="BeginTime不能为空")]
		public DateTime BeginTime { get; set; }



		/// <summary>
		/// EndTime
		/// </summary>
		[Required(ErrorMessage="EndTime不能为空")]
		public DateTime EndTime { get; set; }



		/// <summary>
		/// ContractNo
		/// </summary>
		[Required(ErrorMessage="ContractNo不能为空")]
		public string ContractNo { get; set; }



		/// <summary>
		/// ContractName
		/// </summary>
		[Required(ErrorMessage="ContractName不能为空")]
		public string ContractName { get; set; }



		/// <summary>
		/// ContractAmount
		/// </summary>
		[Required(ErrorMessage="ContractAmount不能为空")]
		public decimal ContractAmount { get; set; }



		/// <summary>
		/// PaidAmount
		/// </summary>
		public decimal PaidAmount { get; set; }



		/// <summary>
		/// ProvisionalAmount
		/// </summary>
		public decimal ProvisionalAmount { get; set; }



		/// <summary>
		/// Tax
		/// </summary>
		public decimal Tax { get; set; }



		/// <summary>
		/// TaxAmount
		/// </summary>
		public decimal TaxAmount { get; set; }



		/// <summary>
		/// IdentifyDate
		/// </summary>
		public DateTime IdentifyDate { get; set; }



		/// <summary>
		/// VendorId
		/// </summary>
		public int VendorId { get; set; }



		/// <summary>
		/// IsClearing
		/// </summary>
		public bool IsClearing { get; set; }



		/// <summary>
		/// ClearingAmount
		/// </summary>
		public decimal ClearingAmount { get; set; }



		/// <summary>
		/// ClearingPer
		/// </summary>
		public decimal ClearingPer { get; set; }



		/// <summary>
		/// FinalPer
		/// </summary>
		public decimal FinalPer { get; set; }



		/// <summary>
		/// Warining
		/// </summary>
		public string Warining { get; set; }



		/// <summary>
		/// WariningDate
		/// </summary>
		public string WariningDate { get; set; }



		/// <summary>
		/// PaymentMethod
		/// </summary>
		public string PaymentMethod { get; set; }



		/// <summary>
		/// Remark
		/// </summary>
		public string Remark { get; set; }



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
		public User AuditUser { get; set; }




    }
}