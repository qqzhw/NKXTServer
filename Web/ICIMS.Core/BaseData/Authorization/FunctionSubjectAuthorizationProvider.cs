

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
    /// See <see cref="FunctionSubjectPermissions" /> for all permission names. FunctionSubject
    ///</summary>
    public class FunctionSubjectAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public FunctionSubjectAuthorizationProvider()
		{

		}

        public FunctionSubjectAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public FunctionSubjectAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了FunctionSubject 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

            var entityPermission = administration.CreateChildPermission(ContractCategoryPermissions.Node, new FixedLocalizableString("基础信息_功能科目"));
            //entityPermission.CreateChildPermission(FunctionSubjectPermissions.Query, L("QueryFunctionSubject"));
            //entityPermission.CreateChildPermission(FunctionSubjectPermissions.Create, L("CreateFunctionSubject"));
            //entityPermission.CreateChildPermission(FunctionSubjectPermissions.Edit, L("EditFunctionSubject"));
            //entityPermission.CreateChildPermission(FunctionSubjectPermissions.Delete, L("DeleteFunctionSubject"));
            //entityPermission.CreateChildPermission(FunctionSubjectPermissions.BatchDelete, L("BatchDeleteFunctionSubject"));
            //entityPermission.CreateChildPermission(FunctionSubjectPermissions.ExportExcel, L("ExportExcelFunctionSubject"));


        }

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}