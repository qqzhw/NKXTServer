
using Abp.Runtime.Validation;
using ICIMS.Dtos;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class GetDocumentCategorysInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
