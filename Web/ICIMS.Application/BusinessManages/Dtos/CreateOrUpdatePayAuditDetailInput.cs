

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdatePayAuditDetailInput
    {
        [Required]
        public PayAuditDetailEditDto PayAuditDetail { get; set; }

    }
}