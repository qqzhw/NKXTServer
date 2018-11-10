

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateItemDefineInput
    {
        [Required]
        public ItemDefineEditDto ItemDefine { get; set; }

    }
}