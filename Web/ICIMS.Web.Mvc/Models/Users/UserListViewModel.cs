using System.Collections.Generic;
using ICIMS.Roles.Dto;
using ICIMS.Users.Dto;

namespace ICIMS.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
