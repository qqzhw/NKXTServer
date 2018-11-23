

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using ICIMS.BusinessManages;
using Abp.Domain.Entities;
using ICIMS.Authorization.Users;

namespace ICIMS.BusinessManages.Dtos
{
    public class PayAuditListDto : Entity, ICreationAudited
    {

        public PayAuditEditDto PayAudit { get; set; }

        public string ItemNo { get; set; }
        public decimal DefineAmount { get; set; }//项目金额
        public string ItemDefineName { get; set; }
        public string UnitName { get; set; }
        public string CreatorUserName { get; set; }
        public string AuditUserName { get; set; }
        public string PaymentTypeName { get; set; }//支付类型
        public string ContractName { get; set; }
        public decimal ContractAmount { get; set; }//合同金额
        public bool IsDeleted { get; set; }

        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
   
 
        public string VendorName { get; set; } //承建单位
        public string AccountName { get; set; }//账户
        public string OpenBank { get; set; }//开户行
        public string LinkPhone { get; set; }//联系人电话

        


    }
}