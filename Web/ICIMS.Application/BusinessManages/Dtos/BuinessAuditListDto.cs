

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;
using ICIMS.Authorization.Roles;
using ICIMS.BussinesManages;
using Abp.Domain.Entities;

namespace ICIMS.BusinessManages.Dtos
{
    public class BuinessAuditListDto : EntityDto,IMayHaveTenant 
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
		public Role RoleId { get; set; }



		/// <summary>
		/// BuinessTypeId
		/// </summary>
		[Required(ErrorMessage="BuinessTypeId不能为空")]
		public int BuinessTypeId { get; set; }



		/// <summary>
		/// Role
		/// </summary>
		public virtual Role Role { get; set; }



		/// <summary>
		/// BuinessType
		/// </summary>
		public virtual BusinessType BuinessType { get; set; }




    }
}