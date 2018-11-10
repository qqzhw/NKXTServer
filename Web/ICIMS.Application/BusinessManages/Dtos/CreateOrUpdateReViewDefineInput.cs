

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateReViewDefineInput
    {
        [Required]
        public ReViewDefineEditDto ReViewDefine { get; set; }

    }
}