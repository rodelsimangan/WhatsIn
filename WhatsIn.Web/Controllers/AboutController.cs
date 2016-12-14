using System.Web.Mvc;

namespace WhatsIn.Web.Controllers
{
    public class AboutController : WhatsInControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}