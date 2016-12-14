using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace WhatsIn.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : WhatsInControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}