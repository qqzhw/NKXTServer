using Abp.Runtime.Validation;
using ICIMS.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData.Dtos
{
    public class GetProjectPropsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
