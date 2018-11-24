

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;
using Abp.Domain.Entities;
using ICIMS.Authorization.Users;

namespace ICIMS.BusinessManages.Dtos
{
    public class ReViewDefineListDto : Entity, ICreationAudited
    {

        public ReViewDefineEditDto ReViewDefine { get; set; }

        public string ItemNo { get; set; }
        public string ItemDefineName { get; set; }
        public string UnitName { get; set; }
        public string CreatorUserName { get; set; }
        public string AuditUserName { get; set; }

        public bool IsDeleted { get; set; }

        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }

}
 