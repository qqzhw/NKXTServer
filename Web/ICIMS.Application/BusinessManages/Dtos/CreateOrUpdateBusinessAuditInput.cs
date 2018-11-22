

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateBusinessAuditInput
    {
        [Required]
        public BusinessAuditEditDto BusinessAudit { get; set; }

    }
}