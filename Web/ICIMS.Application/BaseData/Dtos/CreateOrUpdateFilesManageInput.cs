

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;
using Microsoft.AspNetCore.Http;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateFilesManageInput
    {
        [Required]
        public FilesManageEditDto FilesManage { get; set; }
        public IFormFile FromFile { get; }
    }
}