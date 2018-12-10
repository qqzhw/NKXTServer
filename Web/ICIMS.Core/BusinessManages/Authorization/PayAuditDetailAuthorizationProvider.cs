

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
    /// See <see cref="PayAuditDetailPermissions" /> for all permission names. PayAuditDetail
    ///</summary>
    public class PayAuditDetailAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public PayAuditDetailAuthorizationProvider()
		{

		}

        public PayAuditDetailAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public PayAuditDetailAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了PayAuditDetail 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(PayAuditDetailPermissions.Node , L("PayAuditDetail"));
			//entityPermission.CreateChildPermission(PayAuditDetailPermissions.Query, L("QueryPayAuditDetail"));
			//entityPermission.CreateChildPermission(PayAuditDetailPermissions.Create, L("CreatePayAuditDetail"));
			//entityPermission.CreateChildPermission(PayAuditDetailPermissions.Edit, L("EditPayAuditDetail"));
			//entityPermission.CreateChildPermission(PayAuditDetailPermissions.Delete, L("DeletePayAuditDetail"));
			//entityPermission.CreateChildPermission(PayAuditDetailPermissions.BatchDelete, L("BatchDeletePayAuditDetail"));
			//entityPermission.CreateChildPermission(PayAuditDetailPermissions.ExportExcel, L("ExportExcelPayAuditDetail"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}