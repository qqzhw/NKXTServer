
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.BusinessManages;

namespace  ICIMS.BusinessManages.Dtos
{
    public class PayAuditDetailEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }         


        
		/// <summary>
		/// FundName
		/// </summary>
		[Required(ErrorMessage="FundName不能为空")]
		public string FundName { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// Remark
		/// </summary>
		public string Remark { get; set; }



		/// <summary>
		/// IsDeleted
		/// </summary>
		public bool IsDeleted { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }



		/// <summary>
		/// PayAuditId
		/// </summary>
		[Required(ErrorMessage="PayAuditId不能为空")]
		public int PayAuditId { get; set; }



		/// <summary>
		/// PayAudit
		/// </summary>
		public PayAudit PayAudit { get; set; }



		/// <summary>
		/// Amount
		/// </summary>
		[Required(ErrorMessage="Amount不能为空")]
		public decimal Amount { get; set; }




    }
}