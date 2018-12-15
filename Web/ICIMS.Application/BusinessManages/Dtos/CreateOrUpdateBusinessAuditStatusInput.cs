

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateBusinessAuditStatusInput
    {
        [Required]
        public BusinessAuditStatusEditDto BusinessAuditStatus { get; set; }

    }
}