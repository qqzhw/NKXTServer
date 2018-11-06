using Microsoft.AspNetCore.Antiforgery;
using ICIMS.Controllers;

namespace ICIMS.Web.Host.Controllers
{
    public class AntiForgeryController : ICIMSControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
