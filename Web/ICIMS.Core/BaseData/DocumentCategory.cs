using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData
{
    /// <summary>
    /// 文档分类
    /// </summary>
    public class DocumentCategory : FullAuditedEntity, IMayHaveTenant, IHasCreationTime, IHasDeletionTime, IHasModificationTime
    {

        public string No { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //上级编号
        public int ParentId { get; set; }


        public bool Published { get; set; }


        public int DisplayOrder { get; set; }


        public int? TenantId { get; set; }
    } 
}
