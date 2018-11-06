using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData
{
    /// <summary>
    /// 预算分类
    /// </summary>
    public class YSCategory : Entity, IMayHaveTenant, IHasCreationTime, ISoftDelete, IHasModificationTime
    {

        public string No { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //上级编号
        public int ParentId { get; set; }


        public bool Published { get; set; }


        public int DisplayOrder { get; set; }


        public int? TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    } 
}
