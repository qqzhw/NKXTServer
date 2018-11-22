
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.Authorization.Roles;
using ICIMS.BusinessManages;


namespace  ICIMS.BusinessManages.Dtos
{
    public class BusinessAuditEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// DisplayOrder
		/// </summary>
		public int DisplayOrder { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// RoleId
		/// </summary>
		[Required(ErrorMessage="RoleId不能为空")]
		public Role RoleId { get; set; }



		/// <summary>
		/// BuinessTypeId
		/// </summary>
		[Required(ErrorMessage="BuinessTypeId不能为空")]
		public int BusinessTypeId { get; set; }

        public string BusinessTypeName { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public virtual Role Role { get; set; }



		/// <summary>
		/// BuinessType
		/// </summary>
		public virtual BusinessType BusinessType { get; set; }




    }
}