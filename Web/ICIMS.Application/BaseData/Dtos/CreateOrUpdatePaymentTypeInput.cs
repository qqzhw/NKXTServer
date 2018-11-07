

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdatePaymentTypeInput
    {
        [Required]
        public PaymentTypeEditDto PaymentType { get; set; }

    }
}