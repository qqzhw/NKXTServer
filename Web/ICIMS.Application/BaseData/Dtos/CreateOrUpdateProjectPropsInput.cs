using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateProjectPropsInput
    {
        [Required]
        public ProjectPropsEditDto Item { get; set; }
    }
}
