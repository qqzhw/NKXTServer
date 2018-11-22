

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
    /// See <see cref="BusinessAuditPermissions" /> for all permission names. BusinessAudit
    ///</summary>
    public class BusinessAuditAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BusinessAuditAuthorizationProvider()
		{

		}

        public BusinessAuditAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BusinessAuditAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了BuinessAudit 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(BusinessAuditPermissions.Node , L("BuinessAudit"));
			entityPermission.CreateChildPermission(BusinessAuditPermissions.Query, L("QueryBuinessAudit"));
			entityPermission.CreateChildPermission(BusinessAuditPermissions.Create, L("CreateBuinessAudit"));
			entityPermission.CreateChildPermission(BusinessAuditPermissions.Edit, L("EditBuinessAudit"));
			entityPermission.CreateChildPermission(BusinessAuditPermissions.Delete, L("DeleteBuinessAudit"));
			entityPermission.CreateChildPermission(BusinessAuditPermissions.BatchDelete, L("BatchDeleteBuinessAudit"));
			entityPermission.CreateChildPermission(BusinessAuditPermissions.ExportExcel, L("ExportExcelBuinessAudit"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}