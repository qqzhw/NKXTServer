

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using ICIMS.Authorization;

namespace ICIMS.BaseData.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="VendorPermissions" /> for all permission names. Vendor
    ///</summary>
    public class VendorAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public VendorAuthorizationProvider()
		{

		}

        public VendorAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public VendorAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Vendor 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(VendorPermissions.Node , L("Vendor"));
			entityPermission.CreateChildPermission(VendorPermissions.Query, L("QueryVendor"));
			entityPermission.CreateChildPermission(VendorPermissions.Create, L("CreateVendor"));
			entityPermission.CreateChildPermission(VendorPermissions.Edit, L("EditVendor"));
			entityPermission.CreateChildPermission(VendorPermissions.Delete, L("DeleteVendor"));
			entityPermission.CreateChildPermission(VendorPermissions.BatchDelete, L("BatchDeleteVendor"));
			entityPermission.CreateChildPermission(VendorPermissions.ExportExcel, L("ExportExcelVendor"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}