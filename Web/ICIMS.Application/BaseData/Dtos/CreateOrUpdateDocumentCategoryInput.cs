

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateDocumentCategoryInput
    {
        [Required]
        public DocumentCategoryEditDto DocumentCategory { get; set; }

    }
}