

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
    /// See <see cref="ReViewDefinePermissions" /> for all permission names. ReViewDefine
    ///</summary>
    public class ReViewDefineAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ReViewDefineAuthorizationProvider()
		{

		}

        public ReViewDefineAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ReViewDefineAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了ReViewDefine 的权限。
			//var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			//var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = context.CreatePermission(ReViewDefinePermissions.Node , new FixedLocalizableString("项目管理_评审登记"));
			//entityPermission.CreateChildPermission(ReViewDefinePermissions.Query, L("QueryReViewDefine"));
			//entityPermission.CreateChildPermission(ReViewDefinePermissions.Create, L("CreateReViewDefine"));
			//entityPermission.CreateChildPermission(ReViewDefinePermissions.Edit, L("EditReViewDefine"));
			//entityPermission.CreateChildPermission(ReViewDefinePermissions.Delete, L("DeleteReViewDefine"));
			//entityPermission.CreateChildPermission(ReViewDefinePermissions.BatchDelete, L("BatchDeleteReViewDefine"));
			//entityPermission.CreateChildPermission(ReViewDefinePermissions.ExportExcel, L("ExportExcelReViewDefine"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}