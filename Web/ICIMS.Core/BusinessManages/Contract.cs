﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ICIMS.Authorization.Users;
using ICIMS.BaseData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BusinessManages
{
    /// <summary>
    /// 合同类
    /// </summary>
   public class Contract: FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        /// <summary>
        /// GUID
        /// </summary>
        public string SysGuid { get; set; }

        public int Status { get; set; }

        /// <summary>
        /// 立项登记ID
        /// </summary>
        public int ItemDefineId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public int UintId { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        public int ContractTypeId { get; set; } 
        public  virtual ContractCategory ContractType { get; set; }

        public  DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ContractNo { get; set; }
        public string ContractName { get; set; }

        public decimal ContractAmount { get; set; }

        public decimal PaidAmount { get; set; }

        /// <summary>
        /// 暂列金额
        /// </summary>
        public decimal ProvisionalAmount { get; set; }

        public decimal Tax { get; set; }
        public decimal TaxAmount { get; set; }

        public DateTime IdentifyDate { get; set; }

        public int VendorId { get; set; }

        /// <summary>
        /// 是否结算
        /// </summary>
        public bool IsClearing { get; set; }

        public decimal ClearingAmount { get; set; }

        /// <summary>
        /// 结算前支付比例
        /// </summary>
        public decimal ClearingPer { get; set; }

        /// <summary>
        /// 决算前支付比例
        /// </summary>
        public decimal FinalPer { get; set; }
       

        /// <summary>
        /// 预警
        /// </summary>
        public  string Warining { get; set; }

        /// <summary>
        /// 预警日期
        /// </summary>
       public  string WariningDate { get; set; }

        /// <summary>
        /// 付款方式及比例
        /// </summary>
        public string PaymentMethod { get; set; }

        public string Remark { get; set; }

        /// <summary>
        /// 结审日期
        /// </summary>
        public DateTime AuditDate { get; set; }

        public int? AuditUserId { get; set; }
        
        public virtual User AuditUser { get; set; }

      
    }
}
