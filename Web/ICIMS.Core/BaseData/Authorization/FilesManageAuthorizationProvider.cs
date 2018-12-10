

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
    /// See <see cref="FilesManagePermissions" /> for all permission names. FilesManage
    ///</summary>
    public class FilesManageAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public FilesManageAuthorizationProvider()
		{

		}

        public FilesManageAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public FilesManageAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了FilesManage 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));
            var entityPermission = administration.CreateChildPermission(ContractCategoryPermissions.Node, new FixedLocalizableString("附件下载"));
            //var entityPermission = administration.CreateChildPermission(FilesManagePermissions.Node , L("FilesManage"));
            //entityPermission.CreateChildPermission(FilesManagePermissions.Query, L("QueryFilesManage"));
            //entityPermission.CreateChildPermission(FilesManagePermissions.Create, L("CreateFilesManage"));
            //entityPermission.CreateChildPermission(FilesManagePermissions.Edit, L("EditFilesManage"));
            //entityPermission.CreateChildPermission(FilesManagePermissions.Delete, L("DeleteFilesManage"));
            //entityPermission.CreateChildPermission(FilesManagePermissions.BatchDelete, L("BatchDeleteFilesManage"));
            //entityPermission.CreateChildPermission(FilesManagePermissions.ExportExcel, L("ExportExcelFilesManage"));


        }

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}