

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateContractInput
    {
        [Required]
        public ContractEditDto Contract { get; set; }

    }
}