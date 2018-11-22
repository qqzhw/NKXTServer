
using Abp.Runtime.Validation;
using ICIMS.Dtos;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class GetBusinessAuditsInput : PagedAndSortedInputDto, IShouldNormalize
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
        public string BusinessTypeName { get; set; }
        public int? BusinessTypeId { get; set; }
    }
}
