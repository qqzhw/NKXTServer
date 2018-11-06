using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ICIMS.Controllers
{
    public abstract class ICIMSControllerBase: AbpController
    {
        protected ICIMSControllerBase()
        {
            LocalizationSourceName = ICIMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
