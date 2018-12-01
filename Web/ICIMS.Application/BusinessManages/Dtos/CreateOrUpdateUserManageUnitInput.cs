

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;

namespace ICIMS.BusinessManages.Dtos
{
    public class CreateOrUpdateUserManageUnitInput
    {
        [Required]
        public UserManageUnitEditDto UserManageUnit { get; set; }

    }
}