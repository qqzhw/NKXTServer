using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BusinessManages
{
    public class BusinessType : Entity, IMayHaveTenant,ISoftDelete
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int? TenantId { get; set ; }
        public bool IsDeleted { get ; set ; }
    }
}
