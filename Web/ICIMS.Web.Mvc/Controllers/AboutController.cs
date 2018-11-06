using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using ICIMS.Controllers;

namespace ICIMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ICIMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
