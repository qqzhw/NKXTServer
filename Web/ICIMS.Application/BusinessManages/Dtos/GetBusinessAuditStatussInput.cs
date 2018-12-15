
using Abp.Runtime.Validation;
using ICIMS.Dtos;
using ICIMS.BusinessManages;
using System.Collections.Generic;

namespace ICIMS.BusinessManages.Dtos
{
    public class GetBusinessAuditStatussInput : PagedAndSortedInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

        public int? Status { get; set; }
        public List<int> RoleIds { get; set; }
        public string BusinessTypeName { get; set; }
    }
}
