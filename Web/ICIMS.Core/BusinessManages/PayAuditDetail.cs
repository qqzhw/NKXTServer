using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BusinessManages
{
    public partial class PayAuditDetail: Entity,IMayHaveTenant,ISoftDelete, IHasCreationTime
    {
        /// <summary>
        /// 资金来源名称
        /// </summary>
        public string FundName { get; set; }
        public int? TenantId { get; set ; }
        public string Remark { get; set; }
        public bool IsDeleted { get; set ; }
        public decimal Amount { get; set; }
        public DateTime CreationTime { get ; set ; }
        public int PayAuditId { get; set; }
        public virtual PayAudit PayAudit { get; set; }
    }
}
