

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateAuditMappingInput
    {
        [Required]
        public AuditMappingEditDto AuditMapping { get; set; }

    }
}