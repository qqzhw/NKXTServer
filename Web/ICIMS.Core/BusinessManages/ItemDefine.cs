using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using ICIMS.Authorization.Users;
using ICIMS.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICIMS.BusinessManages
{
    /// <summary>
    /// 立项登记
    /// </summary>
    public class ItemDefine : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        /// <summary>
        /// GUID
        /// </summary>
        public string SysGuid { get; set; }

        /// <summary>
        /// 立项状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public long UnitId { get; set; }
        public virtual OrganizationUnit Unit { get; set; }
        public int? BudgetId { get; set; }
        public virtual Budget Budget { get; set; }
        /// <summary>
        /// 项目立项文号
        /// </summary>
        public string ItemDocNo { get; set; }

        /// <summary>
        /// 立项日期
        /// </summary>
        public DateTime DefineDate { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string ItemNo { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        public int ItemCategoryId { get; set; }//项目类型
        public virtual ItemCategory ItemCategory { get; set; }
        /// <summary>
        /// 立项金额
        /// </summary>
        public decimal DefineAmount { get; set; }

        public string ItemAddress { get; set; }//项目地址   

        public string ItemDescription { get; set; }//项目描述  

        public string Remark { get; set; }//备注  

        /// <summary>
        /// 是否决算
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// 是否评审
        /// </summary>
        [DefaultValue(false)]
        public bool IsAudit { get; set; }

        /// <summary>
        /// 结审日期
        /// </summary>
        public DateTime? AuditDate { get; set; }

        public long? AuditUserId { get; set; }
        [ForeignKey("AuditUserId")]
        public virtual User AuditUser { get; set; }

        public virtual User CreatorUser { get; set; }
    }
}
