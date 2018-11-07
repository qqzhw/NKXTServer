

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateFilesManageInput
    {
        [Required]
        public FilesManageEditDto FilesManage { get; set; }

    }
}