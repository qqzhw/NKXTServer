

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateYSCategoryInput
    {
        [Required]
        public YSCategoryEditDto YSCategory { get; set; }

    }
}