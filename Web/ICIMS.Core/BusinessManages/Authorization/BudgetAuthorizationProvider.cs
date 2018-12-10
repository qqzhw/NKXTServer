

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
    /// See <see cref="BudgetPermissions" /> for all permission names. Budget
    ///</summary>
    public class BudgetAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BudgetAuthorizationProvider()
		{

		}

        public BudgetAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BudgetAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Budget 的权限。
			//var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			//var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = context.CreatePermission(BudgetPermissions.Node , new FixedLocalizableString("项目管理_预算管理"));
			//entityPermission.CreateChildPermission(BudgetPermissions.Query, L("QueryBudget"));
			//entityPermission.CreateChildPermission(BudgetPermissions.Create, L("CreateBudget"));
			//entityPermission.CreateChildPermission(BudgetPermissions.Edit, L("EditBudget"));
			//entityPermission.CreateChildPermission(BudgetPermissions.Delete, L("DeleteBudget"));
			//entityPermission.CreateChildPermission(BudgetPermissions.BatchDelete, L("BatchDeleteBudget"));
			//entityPermission.CreateChildPermission(BudgetPermissions.ExportExcel, L("ExportExcelBudget"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}