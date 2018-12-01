using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;
using ICIMS.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Organizations;
using ICIMS.Users.Dto;

namespace ICIMS.BusinessManages.Dtos
{
    public class UserManageUnitListDto : EntityDto,IMayHaveTenant 
    {

        
		/// <summary>
		/// UserId
		/// </summary>
		[Required(ErrorMessage="UserId不能为空")]
		public long UserId { get; set; }



		/// <summary>
		/// UnitId
		/// </summary>
		[Required(ErrorMessage="UnitId不能为空")]
		public long UnitId { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// User
		/// </summary>
		public UserDto User { get; set; }



		/// <summary>
		/// OrganizationUnit
		/// </summary>
		public UnitDto OrganizationUnit { get; set; }




    }
}