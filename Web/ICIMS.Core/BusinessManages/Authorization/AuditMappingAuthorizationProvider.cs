

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
    /// See <see cref="AuditMappingPermissions" /> for all permission names. AuditMapping
    ///</summary>
    public class AuditMappingAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public AuditMappingAuthorizationProvider()
		{

		}

        public AuditMappingAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public AuditMappingAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了AuditMapping 的权限。
			//var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			//var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = context.CreatePermission(AuditMappingPermissions.Node , new FixedLocalizableString("项目管理_角色审核"));
			//entityPermission.CreateChildPermission(AuditMappingPermissions.Query, L("QueryAuditMapping"));
			//entityPermission.CreateChildPermission(AuditMappingPermissions.Create, L("CreateAuditMapping"));
			//entityPermission.CreateChildPermission(AuditMappingPermissions.Edit, L("EditAuditMapping"));
			//entityPermission.CreateChildPermission(AuditMappingPermissions.Delete, L("DeleteAuditMapping"));
			//entityPermission.CreateChildPermission(AuditMappingPermissions.BatchDelete, L("BatchDeleteAuditMapping"));
			//entityPermission.CreateChildPermission(AuditMappingPermissions.ExportExcel, L("ExportExcelAuditMapping"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}