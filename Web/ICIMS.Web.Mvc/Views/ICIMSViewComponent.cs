using Abp.AspNetCore.Mvc.ViewComponents;

namespace ICIMS.Web.Views
{
    public abstract class ICIMSViewComponent : AbpViewComponent
    {
        protected ICIMSViewComponent()
        {
            LocalizationSourceName = ICIMSConsts.LocalizationSourceName;
        }
    }
}
