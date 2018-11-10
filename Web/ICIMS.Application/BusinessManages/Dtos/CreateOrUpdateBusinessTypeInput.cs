

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 

namespace ICIMS.BussinesManages.Dtos
{
    public class CreateOrUpdateBusinessTypeInput
    {
        [Required]
        public BusinessTypeEditDto BusinessType { get; set; }

    }
}