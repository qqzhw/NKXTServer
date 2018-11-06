

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateBuyCategoryInput
    {
        [Required]
        public BuyCategoryEditDto BuyCategory { get; set; }

    }
}