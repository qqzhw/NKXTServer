using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ICIMS.BussinesManages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BusinessManages
{
    public class AuditMapping : Entity, IMayHaveTenant, ICreationAudited
    {
         
        public int DisplayOrder { get; set; }
        public int? TenantId { get; set; }
        public int BuinessAuditId { get; set; } //审核角色对应ID
        public int BuinessTypeId { get; set; }//业务类型ID
        public int ItemId { get; set; }  //对应业务立项等ID
        
        public int Status { get; set; } //审核状态
        public string AuditOpinion { get; set; }//审核意见
        public long? CreatorUserId {get; set; }
        public DateTime CreationTime { get ; set ; }
        public DateTime? AuditTime { get; set; }

        public virtual BuinessAudit BuinessAudit { get; set; }
    }
     
}
