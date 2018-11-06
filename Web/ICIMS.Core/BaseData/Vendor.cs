using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICIMS.BaseData
{
    /// <summary>
    /// 供应商信息
    /// </summary>
    [Table("Vendor")]
    public class Vendor : FullAuditedEntity, IMayHaveTenant
    {

        public string No { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LinkPerson { get; set; }
        public string LinkPhone { get; set; }
        public string AccountName { get; set; }
        public string OpenBank { get; set; }
        public string Remark { get; set; }
        public int? TenantId { get; set; }
        public bool Published { get; set; }

        public int DisplayOrder { get; set; }
    }
}
