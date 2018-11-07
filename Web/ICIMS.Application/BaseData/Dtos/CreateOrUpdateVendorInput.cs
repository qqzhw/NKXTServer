

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateVendorInput
    {
        [Required]
        public VendorEditDto Vendor { get; set; }

    }
}