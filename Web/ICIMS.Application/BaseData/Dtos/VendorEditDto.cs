
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.BaseData;

namespace  ICIMS.BaseData.Dtos
{
    public class VendorEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }         


        
		/// <summary>
		/// No
		/// </summary>
		[Required(ErrorMessage="编号不能为空")]
		public string No { get; set; }



		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; }



		/// <summary>
		/// Name
		/// </summary>
		[Required(ErrorMessage="Name不能为空")]
		public string Name { get; set; }



		/// <summary>
		/// Address
		/// </summary>
		//[Required(ErrorMessage="Address不能为空")]
		public string Address { get; set; }



		/// <summary>
		/// LinkPerson
		/// </summary>
		//[Required(ErrorMessage="LinkPerson不能为空")]
		public string LinkPerson { get; set; }



		/// <summary>
		/// LinkPhone
		/// </summary>
		//[Required(ErrorMessage="LinkPhone不能为空")]
		public string LinkPhone { get; set; }



		/// <summary>
		/// AccountName
		/// </summary>
		//[Required(ErrorMessage="AccountName不能为空")]
		public string AccountName { get; set; }



		/// <summary>
		/// OpenBank
		/// </summary>
		//[Required(ErrorMessage="OpenBank不能为空")]
		public string OpenBank { get; set; }



		/// <summary>
		/// Remark
		/// </summary>
		public string Remark { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }



		/// <summary>
		/// Published
		/// </summary>
		public bool Published { get; set; }



		/// <summary>
		/// DisplayOrder
		/// </summary>
		public int DisplayOrder { get; set; }




    }
}