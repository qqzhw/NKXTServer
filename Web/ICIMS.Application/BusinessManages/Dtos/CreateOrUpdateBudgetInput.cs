

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateBudgetInput
    {
        [Required]
        public BudgetEditDto Budget { get; set; }

    }
}