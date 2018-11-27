
using Abp.Runtime.Validation;
using ICIMS.Dtos;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class GetPayAuditDetailsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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

    }
}
