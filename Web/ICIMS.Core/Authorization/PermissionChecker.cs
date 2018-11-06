using Abp.Authorization;
using ICIMS.Authorization.Roles;
using ICIMS.Authorization.Users;

namespace ICIMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
