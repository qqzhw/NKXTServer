

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdatePayAuditInput
    {
        [Required]
        public PayAuditEditDto PayAudit { get; set; }

    }
}