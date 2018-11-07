

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateItemCategoryInput
    {
        [Required]
        public ItemCategoryEditDto ItemCategory { get; set; }

    }
}