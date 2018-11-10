

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
    /// See <see cref="ContractPermissions" /> for all permission names. Contract
    ///</summary>
    public class ContractAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ContractAuthorizationProvider()
		{

		}

        public ContractAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ContractAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Contract 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(ContractPermissions.Node , L("Contract"));
			entityPermission.CreateChildPermission(ContractPermissions.Query, L("QueryContract"));
			entityPermission.CreateChildPermission(ContractPermissions.Create, L("CreateContract"));
			entityPermission.CreateChildPermission(ContractPermissions.Edit, L("EditContract"));
			entityPermission.CreateChildPermission(ContractPermissions.Delete, L("DeleteContract"));
			entityPermission.CreateChildPermission(ContractPermissions.BatchDelete, L("BatchDeleteContract"));
			entityPermission.CreateChildPermission(ContractPermissions.ExportExcel, L("ExportExcelContract"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}