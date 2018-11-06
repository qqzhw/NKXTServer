using System.Collections.Generic;
using ICIMS.Roles.Dto;

namespace ICIMS.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}