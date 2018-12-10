using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ICIMS.Authorization
{
    public class ICIMSAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, new FixedLocalizableString("用户管理"));
            context.CreatePermission(PermissionNames.Pages_Roles, new FixedLocalizableString("角色管理"));
            context.CreatePermission(PermissionNames.Pages_Tenants, new FixedLocalizableString("账套管理"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
        }
    }
}
