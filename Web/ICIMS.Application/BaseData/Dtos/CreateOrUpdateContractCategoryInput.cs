

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateContractCategoryInput
    {
        [Required]
        public ContractCategoryEditDto ContractCategory { get; set; }

    }
}