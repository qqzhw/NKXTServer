using Abp.Domain.Entities;
using Abp.Organizations;
using ICIMS.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BusinessManages
{
    public class UserManageUnit : Entity, IMayHaveTenant
    {
        public long UserId { get; set; }

        public long UnitId { get; set; }

        public int? TenantId { get; set; }

        public virtual User User{get;set;}

        public virtual OrganizationUnit OrganizationUnit { get; set; }
    }
}
