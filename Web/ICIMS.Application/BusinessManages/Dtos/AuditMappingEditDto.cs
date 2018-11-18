
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.BusinessManages;

namespace  ICIMS.BusinessManages.Dtos
{
    public class AuditMappingEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
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
		[Required(ErrorMessage="BuinessAuditId不能为空")]
		public int BuinessAuditId { get; set; }



		/// <summary>
		/// BuinessTypeId
		/// </summary>
		[Required(ErrorMessage="BuinessTypeId不能为空")]
		public int BuinessTypeId { get; set; }



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




    }
}