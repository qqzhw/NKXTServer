
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.BusinessManages;

namespace  ICIMS.BusinessManages.Dtos
{
    public class BusinessAuditStatusEditDto
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




    }
}