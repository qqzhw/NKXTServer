

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;
using Abp.Domain.Entities;

namespace ICIMS.BaseData.Dtos
{
    public class BuyCategoryListDto : FullAuditedEntityDto,IMayHaveTenant,IHasCreationTime,IHasDeletionTime,IHasModificationTime 
    {

        
		/// <summary>
		/// No
		/// </summary>
		[MaxLength(100, ErrorMessage="No超出最大长度")]
		[Required(ErrorMessage="No不能为空")]
		public string No { get; set; }



		/// <summary>
		/// Name
		/// </summary>
		[MaxLength(100, ErrorMessage="Name超出最大长度")]
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// Description
		/// </summary>
		[MaxLength(1000, ErrorMessage="Description超出最大长度")]
		public string Description { get; set; }



		/// <summary>
		/// ParentId
		/// </summary>
		public int ParentId { get; set; }



		/// <summary>
		/// Published
		/// </summary>
		public bool Published { get; set; }



		/// <summary>
		/// DisplayOrder
		/// </summary>
		public int DisplayOrder { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }




    }
}