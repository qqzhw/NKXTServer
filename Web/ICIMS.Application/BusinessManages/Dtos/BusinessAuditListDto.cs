

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;
using ICIMS.Authorization.Roles;
 
using Abp.Domain.Entities;
using ICIMS.Roles.Dto;

namespace ICIMS.BusinessManages.Dtos
{
    public class BusinessAuditListDto : EntityDto,IMayHaveTenant 
    {

        
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
		public int RoleId { get; set; }

        public string RoleName { get; set; }

		/// <summary>
		/// BuinessTypeId
		/// </summary>
		[Required(ErrorMessage="BusinessTypeId不能为空")]
		public int BusinessTypeId { get; set; }

        public string BusinessTypeName { get; set; }

        /// <summary>
        /// Role
        /// </summary>
       // public virtual RoleDto Role { get; set; }

         public int EntityId { get; set; }

        public int Status { get; set; }
        public int BusinessAuditStatusId { get; set; }
    }
}