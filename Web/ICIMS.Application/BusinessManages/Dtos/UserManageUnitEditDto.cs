
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.BusinessManages;

namespace  ICIMS.BusinessManages.Dtos
{
    public class UserManageUnitEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
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
         
    }
}