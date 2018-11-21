using Abp.Authorization.Roles;
using Abp.Domain.Entities;
using ICIMS.Authorization.Roles;
using ICIMS.BussinesManages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BusinessManages
{
    public class BuinessAudit : Entity, IMayHaveTenant
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int? TenantId { get; set; }
        public int RoleId { get; set; }  //角色ID
        public int BuinessTypeId { get; set; }//业务类型ID
        public string BuinessTypeName { get; set; }
        public virtual Role Role { get; set; }
        public virtual BusinessType BuinessType{get;set;}
    }
}
    
 
