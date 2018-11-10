

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
    /// See <see cref="ItemDefinePermissions" /> for all permission names. ItemDefine
    ///</summary>
    public class ItemDefineAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ItemDefineAuthorizationProvider()
		{

		}

        public ItemDefineAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ItemDefineAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了ItemDefine 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(ItemDefinePermissions.Node , L("ItemDefine"));
			entityPermission.CreateChildPermission(ItemDefinePermissions.Query, L("QueryItemDefine"));
			entityPermission.CreateChildPermission(ItemDefinePermissions.Create, L("CreateItemDefine"));
			entityPermission.CreateChildPermission(ItemDefinePermissions.Edit, L("EditItemDefine"));
			entityPermission.CreateChildPermission(ItemDefinePermissions.Delete, L("DeleteItemDefine"));
			entityPermission.CreateChildPermission(ItemDefinePermissions.BatchDelete, L("BatchDeleteItemDefine"));
			entityPermission.CreateChildPermission(ItemDefinePermissions.ExportExcel, L("ExportExcelItemDefine"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}