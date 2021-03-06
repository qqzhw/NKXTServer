﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using ICIMS.Authorization.Users;
using ICIMS.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ICIMS.BusinessManages
{
    public class PayAudit : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string SysGuid { get; set; }

        public int Status { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public long? UnitId { get; set; }

       
        public decimal? InitPayAmount { get; set; }
        /// <summary>
        /// 合同ID
        /// </summary>
        public int ContrctId { get; set; }

        /// <summary>
        /// 立项登记ID
        /// </summary>
        public int ItemDefineId { get; set; }
        /// <summary>
        ///支付类型ID
        /// </summary>
        public int PaymentTypeId { get; set; }
        /// <summary>
        /// 支付编号
        /// </summary>
        public string PaymentNo { get; set; }
        public string PaymentName { get; set; }
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 支付比例
        /// </summary>
        public int PaymentPer { get; set; }
        /// <summary>
        /// 支付次数
        /// </summary>
        public int PaymentCount { get; set; }

        /// <summary>
        /// 项目预算总额
        /// </summary>
        public decimal? ItemYsTotalAmount { get; set; }

        /// <summary>
        /// 项目总额
        /// </summary>
        public decimal ItemTotalAmount { get; set; }

        /// <summary>
        /// 合同总额
        /// </summary>
        public decimal ContractTotalAmount { get; set; }

        /// <summary>
        /// 支付方式及比例
        /// </summary>
        public string PaymentMethod { get; set; }
        public string Remark { get; set; }

        /// <summary>
        /// 结审日期
        /// </summary>
        public DateTime? AuditDate { get; set; }

        public long? AuditUserId { get; set; }

        public virtual User AuditUser { get; set; } 
        
        #region 导航属性 
        public virtual Contract Contract { get; set; } 
        public virtual PaymentType PaymentType { get; set; }
        public virtual ItemDefine ItemDefine { get; set; }
        public virtual User CreatorUser { get; set; }
        #endregion

    }
}
