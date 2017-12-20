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
    //[AbpMvcAuthorize]
    public class HomeController : WhatsInControllerBase
    {
        private readonly IStoreAppService _storeAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly ILocationAppService _locationAppService;
        private readonly IProvinceAppService _provinceAppService;

        public HomeController(IStoreAppService appService, ICategoryAppService categoryAppService, ILocationAppService locationAppService, IProvinceAppService provinceAppService)
        {
            _storeAppService = appService;
            _categoryAppService = categoryAppService;
            _locationAppService = locationAppService;
            _provinceAppService = provinceAppService;
        }

        public ActionResult Index()
        {
            return View();
           // return RedirectToAction("", "Search");
        }

        public virtual async Task<JsonResult> Result()
        {
            try
            {
                SearchViewModel model = new SearchViewModel();
                model.Stores = new List<StoreDto>();
                var output = await _storeAppService.GetStores(null, false);
                model.Stores = output;
                //return  Json(model);
                //Redirect(")
                //return (model);
                // return RedirectToAction("Index", "Home");
                return Json(model, JsonRequestBehavior.AllowGet);
                //return View("Index", model);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<JsonResult> GetSidebarCategories()
        {
            try
            {
                //List<Province> prov = new List<Province>();
                var output = await _categoryAppService.GetCategories(null, false);
                /*for (int i = 0; i < output.Count(); i++)
                {
                    prov.Add(new Province() { text = output[i].Description, parentId = output[i].Id.ToString() });
                }*/
              
                return Json(output, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}