

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
    /// See <see cref="ContractCategoryPermissions" /> for all permission names. ContractCategory
    ///</summary>
    public class ContractCategoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ContractCategoryAuthorizationProvider()
		{

		}

        public ContractCategoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ContractCategoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了ContractCategory 的权限。
			//var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			//var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = context.CreatePermission(ContractCategoryPermissions.Node , new FixedLocalizableString("基础信息_合同分类"));
            //context.CreatePermission(BuyCategoryPermissions.Query, new FixedLocalizableString("基础信息_采购分类"));
            //entityPermission.CreateChildPermission(ContractCategoryPermissions.Query, L("QueryContractCategory"));
            //entityPermission.CreateChildPermission(ContractCategoryPermissions.Create, L("CreateContractCategory"));
            //entityPermission.CreateChildPermission(ContractCategoryPermissions.Edit, L("EditContractCategory"));
            //entityPermission.CreateChildPermission(ContractCategoryPermissions.Delete, L("DeleteContractCategory"));
            //entityPermission.CreateChildPermission(ContractCategoryPermissions.BatchDelete, L("BatchDeleteContractCategory"));
            //entityPermission.CreateChildPermission(ContractCategoryPermissions.ExportExcel, L("ExportExcelContractCategory"));


        }

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}