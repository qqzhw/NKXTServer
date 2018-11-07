

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
    /// See <see cref="FundFromPermissions" /> for all permission names. FundFrom
    ///</summary>
    public class FundFromAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public FundFromAuthorizationProvider()
		{

		}

        public FundFromAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public FundFromAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了FundFrom 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(FundFromPermissions.Node , L("FundFrom"));
			entityPermission.CreateChildPermission(FundFromPermissions.Query, L("QueryFundFrom"));
			entityPermission.CreateChildPermission(FundFromPermissions.Create, L("CreateFundFrom"));
			entityPermission.CreateChildPermission(FundFromPermissions.Edit, L("EditFundFrom"));
			entityPermission.CreateChildPermission(FundFromPermissions.Delete, L("DeleteFundFrom"));
			entityPermission.CreateChildPermission(FundFromPermissions.BatchDelete, L("BatchDeleteFundFrom"));
			entityPermission.CreateChildPermission(FundFromPermissions.ExportExcel, L("ExportExcelFundFrom"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}