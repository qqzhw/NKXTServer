using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICIMS.BaseData.Authorization
{
    public class ProjectPropsAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public ProjectPropsAuthorizationProvider()
        {

        }

        public ProjectPropsAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ProjectPropsAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了DocumentCategory 的权限。
            //var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

            //var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

            var entityPermission = context.CreatePermission(ProjectPropsPermissions.Node, new FixedLocalizableString("基础信息_项目属性"));
            //entityPermission.CreateChildPermission(DocumentCategoryPermissions.Query, L("QueryDocumentCategory"));
            //entityPermission.CreateChildPermission(DocumentCategoryPermissions.Create, L("CreateDocumentCategory"));
            //entityPermission.CreateChildPermission(DocumentCategoryPermissions.Edit, L("EditDocumentCategory"));
            //entityPermission.CreateChildPermission(DocumentCategoryPermissions.Delete, L("DeleteDocumentCategory"));
            //entityPermission.CreateChildPermission(DocumentCategoryPermissions.BatchDelete, L("BatchDeleteDocumentCategory"));
            //entityPermission.CreateChildPermission(DocumentCategoryPermissions.ExportExcel, L("ExportExcelDocumentCategory"));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
        }
    }
}
