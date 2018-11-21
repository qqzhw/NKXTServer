
using Abp.Runtime.Validation;
using ICIMS.Dtos;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class GetFilesManagesInput : PagedAndSortedInputDto, IShouldNormalize
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

        public string UploadType { get; set; }

        public int? EntityId { get; set; }

        public string EntityKey { get; set; }

        public string EntityName { get; set; }

    }
}
