

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
    /// See <see cref="DocumentCategoryPermissions" /> for all permission names. DocumentCategory
    ///</summary>
    public class DocumentCategoryAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public DocumentCategoryAuthorizationProvider()
		{

		}

        public DocumentCategoryAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public DocumentCategoryAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了DocumentCategory 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(DocumentCategoryPermissions.Node , L("DocumentCategory"));
			entityPermission.CreateChildPermission(DocumentCategoryPermissions.Query, L("QueryDocumentCategory"));
			entityPermission.CreateChildPermission(DocumentCategoryPermissions.Create, L("CreateDocumentCategory"));
			entityPermission.CreateChildPermission(DocumentCategoryPermissions.Edit, L("EditDocumentCategory"));
			entityPermission.CreateChildPermission(DocumentCategoryPermissions.Delete, L("DeleteDocumentCategory"));
			entityPermission.CreateChildPermission(DocumentCategoryPermissions.BatchDelete, L("BatchDeleteDocumentCategory"));
			entityPermission.CreateChildPermission(DocumentCategoryPermissions.ExportExcel, L("ExportExcelDocumentCategory"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}