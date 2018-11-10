using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BussinesManages
{
    public class BusinessType : Entity, IMayHaveTenant,ISoftDelete
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int? TenantId { get; set ; }
        public bool IsDeleted { get ; set ; }
    }
}
