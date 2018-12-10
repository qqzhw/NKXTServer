

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
    /// See <see cref="BuyCategoryPermissions" /> for all permission names. BuyCategory
    ///</summary>
    public class BuyCategoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BuyCategoryAuthorizationProvider()
		{

		}

        public BuyCategoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BuyCategoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
 
            // 在这里配置了BuyCategory 的权限。
            //var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

            //var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

            var entityPermission = context.CreatePermission(BuyCategoryPermissions.Node , new FixedLocalizableString("基础信息_采购分类"));
            //var entityPermission = administration.CreateChildPermission(BuyCategoryPermissions.Node, new FixedLocalizableString("基础信息_采购分类"));
            //entityPermission.CreateChildPermission(BuyCategoryPermissions.Query, L("QueryBuyCategory"));
            //entityPermission.CreateChildPermission(BuyCategoryPermissions.Create, L("CreateBuyCategory"));
            //entityPermission.CreateChildPermission(BuyCategoryPermissions.Edit, L("EditBuyCategory"));
            //entityPermission.CreateChildPermission(BuyCategoryPermissions.Delete, L("DeleteBuyCategory"));
            //entityPermission.CreateChildPermission(BuyCategoryPermissions.BatchDelete, L("BatchDeleteBuyCategory"));
            //entityPermission.CreateChildPermission(BuyCategoryPermissions.ExportExcel, L("ExportExcelBuyCategory"));


        }

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}