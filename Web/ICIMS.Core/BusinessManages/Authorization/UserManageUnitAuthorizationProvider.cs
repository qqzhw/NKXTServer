

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using ICIMS.Authorization;

namespace ICIMS.BusinessManages.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="UserManageUnitPermissions" /> for all permission names. UserManageUnit
    ///</summary>
    public class UserManageUnitAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public UserManageUnitAuthorizationProvider()
		{

		}

        public UserManageUnitAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public UserManageUnitAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了UserManageUnit 的权限。
			//var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			//var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = context.CreatePermission(UserManageUnitPermissions.Node , new FixedLocalizableString("UserManageUnit"));
			//entityPermission.CreateChildPermission(UserManageUnitPermissions.Query, L("QueryUserManageUnit"));
			//entityPermission.CreateChildPermission(UserManageUnitPermissions.Create, L("CreateUserManageUnit"));
			//entityPermission.CreateChildPermission(UserManageUnitPermissions.Edit, L("EditUserManageUnit"));
			//entityPermission.CreateChildPermission(UserManageUnitPermissions.Delete, L("DeleteUserManageUnit"));
			//entityPermission.CreateChildPermission(UserManageUnitPermissions.BatchDelete, L("BatchDeleteUserManageUnit"));
			//entityPermission.CreateChildPermission(UserManageUnitPermissions.ExportExcel, L("ExportExcelUserManageUnit"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}