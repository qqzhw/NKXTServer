using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BusinessManages
{
    public class BusinessAuditStatus : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; } 
        public int EntityId { get; set; }
        public string BusinessTypeName { get; set; }
        public int Status { get; set; }
        public int BusinessAuditId { get; set; }
        public virtual BusinessAudit BusinessAudit { get; set; }
        public int DisplayOrder { get; set; }

    }
}
