

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ICIMS.BaseData;

namespace ICIMS.BaseData.Dtos
{
    public class CreateOrUpdateFunctionSubjectInput
    {
        [Required]
        public FunctionSubjectEditDto FunctionSubject { get; set; }

    }
}