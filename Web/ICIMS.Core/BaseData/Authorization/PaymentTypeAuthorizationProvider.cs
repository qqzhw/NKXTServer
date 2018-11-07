

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
    /// See <see cref="PaymentTypePermissions" /> for all permission names. PaymentType
    ///</summary>
    public class PaymentTypeAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public PaymentTypeAuthorizationProvider()
		{

		}

        public PaymentTypeAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public PaymentTypeAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了PaymentType 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(PaymentTypePermissions.Node , L("PaymentType"));
			entityPermission.CreateChildPermission(PaymentTypePermissions.Query, L("QueryPaymentType"));
			entityPermission.CreateChildPermission(PaymentTypePermissions.Create, L("CreatePaymentType"));
			entityPermission.CreateChildPermission(PaymentTypePermissions.Edit, L("EditPaymentType"));
			entityPermission.CreateChildPermission(PaymentTypePermissions.Delete, L("DeletePaymentType"));
			entityPermission.CreateChildPermission(PaymentTypePermissions.BatchDelete, L("BatchDeletePaymentType"));
			entityPermission.CreateChildPermission(PaymentTypePermissions.ExportExcel, L("ExportExcelPaymentType"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, ICIMSConsts.LocalizationSourceName);
		}
    }
}