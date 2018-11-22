

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateBusinessTypeInput
    {
        [Required]
        public BusinessTypeEditDto BusinessType { get; set; }

    }
}