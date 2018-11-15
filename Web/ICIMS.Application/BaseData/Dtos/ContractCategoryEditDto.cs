
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.BaseData;

namespace  ICIMS.BaseData.Dtos
{
    public class ContractCategoryEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }         


        
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



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }



		/// <summary>
		/// LastModificationTime
		/// </summary>
		public DateTime? LastModificationTime { get; set; }



		/// <summary>
		/// IsDeleted
		/// </summary>
		public bool IsDeleted { get; set; }




    }
}