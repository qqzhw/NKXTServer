

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
    /// See <see cref="ItemCategoryPermissions" /> for all permission names. ItemCategory
    ///</summary>
    public class ItemCategoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ItemCategoryAuthorizationProvider()
		{

		}

        public ItemCategoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ItemCategoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了ItemCategory 的权限。
			//var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			//var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = context.CreatePermission(ItemCategoryPermissions.Node , new FixedLocalizableString("基础信息_项目分类"));
			//entityPermission.CreateChildPermission(ItemCategoryPermissions.Query, L("QueryItemCategory"));
			//entityPermission.CreateChildPermission(ItemCategoryPermissions.Create, L("CreateItemCategory"));
			//entityPermission.CreateChildPermission(ItemCategoryPermissions.Edit, L("EditItemCategory"));
			//entityPermission.CreateChildPermission(ItemCategoryPermissions.Delete, L("DeleteItemCategory"));
			//entityPermission.CreateChildPermission(ItemCategoryPermissions.BatchDelete, L("BatchDeleteItemCategory"));
			//entityPermission.CreateChildPermission(ItemCategoryPermissions.ExportExcel, L("ExportExcelItemCategory"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}