

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateFundFromInput
    {
        [Required]
        public FundFromEditDto FundFrom { get; set; }

    }
}