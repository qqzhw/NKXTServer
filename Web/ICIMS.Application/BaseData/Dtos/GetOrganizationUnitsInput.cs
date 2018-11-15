using ICIMS.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData.Dtos
{
   public class GetOrganizationUnitsInput: PagedAndSortedInputDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
