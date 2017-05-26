using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using WhatsIn.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using WhatsIn.Web.Models;
using WhatsIn.Application.Dto;
using Abp.Auditing;
using Abp.Web.Models;
using Abp.Domain.Uow;

namespace WhatsIn.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : WhatsInControllerBase
    {
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("", "Search");
        }    
    }

    
}