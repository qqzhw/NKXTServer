﻿using Abp.Authorization.Roles;
using Abp.Domain.Entities;
using ICIMS.Authorization.Roles;

using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BusinessManages
{
    public class BusinessAudit : Entity, IMayHaveTenant
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int? TenantId { get; set; }
        public int RoleId { get; set; }  //角色ID
        public int BusinessTypeId { get; set; }//业务类型ID
        public string BusinessTypeName { get; set; }
        public  Role Role { get; set; }
        public  BusinessType BusinessType{get;set;}
    }
}
    
 
