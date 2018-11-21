
using Abp.Runtime.Validation;
using ICIMS.Dtos;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class GetBuinessAuditsInput : PagedAndSortedInputDto, IShouldNormalize
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
        public string BuinessTypeName { get; set; }
        public int? BuinessTypeId { get; set; }
    }
}
