using System.Collections.Generic;
using System.Linq;
using ICIMS.Roles.Dto;
using ICIMS.Users.Dto;

namespace ICIMS.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.Roles != null && User.Roles.Any(r => r.Id== role.Id);
        }
    }
}
