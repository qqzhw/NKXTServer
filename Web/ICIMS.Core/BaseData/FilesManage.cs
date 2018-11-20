using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData
{
    /// <summary>
    /// 文档管理
    /// </summary>
    public class FilesManage : FullAuditedEntity, IMayHaveTenant
    {
        public int? EntityId { get; set; }

        public string EntityKey { get; set; }

        public string EntityName { get; set; }
        /// <summary>
        /// Gets or sets a GUID
        /// </summary>
        public Guid DownloadGuid { get; set; }

        public string DownloadUrl { get; set; }

        public string UploadType { get; set; }

        
        public string ContentType { get; set; }


        public string FileName { get; set; }

        public long FileSize { get; set; }

        public string Extension { get; set; }
        public int DisplayOrder { get; set; }
         
        public int? TenantId { get; set; }

    }
}
 