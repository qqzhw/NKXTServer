

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateBuinessAuditInput
    {
        [Required]
        public BuinessAuditEditDto BuinessAudit { get; set; }

    }
}