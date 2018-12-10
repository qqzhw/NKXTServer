

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
    /// See <see cref="YSCategoryPermissions" /> for all permission names. YSCategory
    ///</summary>
    public class YSCategoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public YSCategoryAuthorizationProvider()
		{

		}

        public YSCategoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public YSCategoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了YSCategory 的权限。
			//var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			//var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = context.CreatePermission(YSCategoryPermissions.Node , new FixedLocalizableString("基础信息_预算分类"));
			//entityPermission.CreateChildPermission(YSCategoryPermissions.Query, L("QueryYSCategory"));
			//entityPermission.CreateChildPermission(YSCategoryPermissions.Create, L("CreateYSCategory"));
			//entityPermission.CreateChildPermission(YSCategoryPermissions.Edit, L("EditYSCategory"));
			//entityPermission.CreateChildPermission(YSCategoryPermissions.Delete, L("DeleteYSCategory"));
			//entityPermission.CreateChildPermission(YSCategoryPermissions.BatchDelete, L("BatchDeleteYSCategory"));
			//entityPermission.CreateChildPermission(YSCategoryPermissions.ExportExcel, L("ExportExcelYSCategory"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}