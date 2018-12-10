

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
    /// See <see cref="BusinessTypePermissions" /> for all permission names. BusinessType
    ///</summary>
    public class BusinessTypeAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BusinessTypeAuthorizationProvider()
		{

		}

        public BusinessTypeAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BusinessTypeAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了BusinessType 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(BusinessTypePermissions.Node , L("系统管理_业务类型"));
			//entityPermission.CreateChildPermission(BusinessTypePermissions.Query, L("QueryBusinessType"));
			//entityPermission.CreateChildPermission(BusinessTypePermissions.Create, L("CreateBusinessType"));
			//entityPermission.CreateChildPermission(BusinessTypePermissions.Edit, L("EditBusinessType"));
			//entityPermission.CreateChildPermission(BusinessTypePermissions.Delete, L("DeleteBusinessType"));
			//entityPermission.CreateChildPermission(BusinessTypePermissions.BatchDelete, L("BatchDeleteBusinessType"));
			//entityPermission.CreateChildPermission(BusinessTypePermissions.ExportExcel, L("ExportExcelBusinessType"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}