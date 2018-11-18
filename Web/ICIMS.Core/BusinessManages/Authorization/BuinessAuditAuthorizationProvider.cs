

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
    /// See <see cref="BuinessAuditPermissions" /> for all permission names. BuinessAudit
    ///</summary>
    public class BuinessAuditAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BuinessAuditAuthorizationProvider()
		{

		}

        public BuinessAuditAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BuinessAuditAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了BuinessAudit 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(BuinessAuditPermissions.Node , L("BuinessAudit"));
			entityPermission.CreateChildPermission(BuinessAuditPermissions.Query, L("QueryBuinessAudit"));
			entityPermission.CreateChildPermission(BuinessAuditPermissions.Create, L("CreateBuinessAudit"));
			entityPermission.CreateChildPermission(BuinessAuditPermissions.Edit, L("EditBuinessAudit"));
			entityPermission.CreateChildPermission(BuinessAuditPermissions.Delete, L("DeleteBuinessAudit"));
			entityPermission.CreateChildPermission(BuinessAuditPermissions.BatchDelete, L("BatchDeleteBuinessAudit"));
			entityPermission.CreateChildPermission(BuinessAuditPermissions.ExportExcel, L("ExportExcelBuinessAudit"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}