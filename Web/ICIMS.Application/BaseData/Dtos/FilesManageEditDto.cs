
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using ICIMS.BaseData;

namespace  ICIMS.BaseData.Dtos
{
    public class FilesManageEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// DownloadGuid
		/// </summary>
		public Guid DownloadGuid { get; set; }



		/// <summary>
		/// DownloadUrl
		/// </summary>
		public string DownloadUrl { get; set; }



		/// <summary>
		/// UploadType
		/// </summary>
		public string UploadType { get; set; }



		/// <summary>
		/// ContentType
		/// </summary>
		public string ContentType { get; set; }



		/// <summary>
		/// FileName
		/// </summary>
		[Required(ErrorMessage="FileName不能为空")]
		public string FileName { get; set; }



		/// <summary>
		/// FileSize
		/// </summary>
		public long FileSize { get; set; }



		/// <summary>
		/// Extension
		/// </summary>
		public string Extension { get; set; }



		/// <summary>
		/// DisplayOrder
		/// </summary>
		public int DisplayOrder { get; set; }



		/// <summary>
		/// IsNew
		/// </summary>
		public bool IsNew { get; set; }



		/// <summary>
		/// TenantId
		/// </summary>
		public int? TenantId { get; set; }




    }
}