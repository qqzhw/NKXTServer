

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
    /// See <see cref="PayAuditPermissions" /> for all permission names. PayAudit
    ///</summary>
    public class PayAuditAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public PayAuditAuthorizationProvider()
		{

		}

        public PayAuditAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public PayAuditAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了PayAudit 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(PayAuditPermissions.Node , L("PayAudit"));
			entityPermission.CreateChildPermission(PayAuditPermissions.Query, L("QueryPayAudit"));
			entityPermission.CreateChildPermission(PayAuditPermissions.Create, L("CreatePayAudit"));
			entityPermission.CreateChildPermission(PayAuditPermissions.Edit, L("EditPayAudit"));
			entityPermission.CreateChildPermission(PayAuditPermissions.Delete, L("DeletePayAudit"));
			entityPermission.CreateChildPermission(PayAuditPermissions.BatchDelete, L("BatchDeletePayAudit"));
			entityPermission.CreateChildPermission(PayAuditPermissions.ExportExcel, L("ExportExcelPayAudit"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}