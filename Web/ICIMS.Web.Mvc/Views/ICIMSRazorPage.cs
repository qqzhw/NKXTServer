using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace ICIMS.Web.Views
{
    public abstract class ICIMSRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ICIMSRazorPage()
        {
            LocalizationSourceName = ICIMSConsts.LocalizationSourceName;
        }
    }
}
