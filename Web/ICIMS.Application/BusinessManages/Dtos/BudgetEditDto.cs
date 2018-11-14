
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.BusinessManages;

namespace  ICIMS.BusinessManages.Dtos
{
    public class BudgetEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// TenantId
		/// </summary> 
		public int? TenantId { get; set; }



		/// <summary>
		/// SysGuid
		/// </summary>	 
		public string SysGuid { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		[Required(ErrorMessage="Status不能为空")]
		public int Status { get; set; }



		/// <summary>
		/// Year
		/// </summary>
		[Required(ErrorMessage="Year不能为空")]
		public int Year { get; set; }



		/// <summary>
		/// BudgetNo
		/// </summary>
		[Required(ErrorMessage="BudgetNo不能为空")]
		public string BudgetNo { get; set; }



		/// <summary>
		/// BudgetName
		/// </summary>
		[Required(ErrorMessage="BudgetName不能为空")]
		public string BudgetName { get; set; }



		/// <summary>
		/// According
		/// </summary>
		[Required(ErrorMessage="According不能为空")]
		public string According { get; set; }



		/// <summary>
		/// MeasureStandard
		/// </summary>
		[Required(ErrorMessage="MeasureStandard不能为空")]
		public string MeasureStandard { get; set; }



		/// <summary>
		/// BudgetAmount
		/// </summary>
		[Required(ErrorMessage="BudgetAmount不能为空")]
		public decimal BudgetAmount { get; set; }



		/// <summary>
		/// YsCategoryId
		/// </summary>
		[Required(ErrorMessage="YsCategoryId不能为空")]
		public int YsCategoryId { get; set; }



		/// <summary>
		/// BuyCategoryId
		/// </summary>
		[Required(ErrorMessage="BuyCategoryId不能为空")]
		public int BuyCategoryId { get; set; }



		/// <summary>
		/// SubjectId
		/// </summary>
		[Required(ErrorMessage="SubjectId不能为空")]
		public int SubjectId { get; set; }

        public long UnitId { get; set; }

		/// <summary>
		/// OneAmount
		/// </summary>
		public decimal OneAmount { get; set; }



		/// <summary>
		/// SecondAmount
		/// </summary>
		public decimal SecondAmount { get; set; }



		/// <summary>
		/// InitAmount
		/// </summary>
		public decimal InitAmount { get; set; }



		/// <summary>
		/// MiddleAmount
		/// </summary>
		public decimal MiddleAmount { get; set; }



		/// <summary>
		/// IsMiddle
		/// </summary>
		[Required(ErrorMessage="IsMiddle不能为空")]
		public bool IsMiddle { get; set; }



		/// <summary>
		/// MiddleReplyAmount
		/// </summary>
		[Required(ErrorMessage="MiddleReplyAmount不能为空")]
		public decimal MiddleReplyAmount { get; set; }



		/// <summary>
		/// Remark
		/// </summary>
		public string Remark { get; set; }




    }
}