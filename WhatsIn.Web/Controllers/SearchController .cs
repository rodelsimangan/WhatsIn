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
    public class SearchController : WhatsInControllerBase
    {
        private readonly IStoreAppService _storeAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly ILocationAppService _locationAppService;
        private readonly IProvinceAppService _provinceAppService;

        public SearchController(IStoreAppService appService, ICategoryAppService categoryAppService, ILocationAppService locationAppService, IProvinceAppService provinceAppService)
        {
            _storeAppService = appService;
            _categoryAppService = categoryAppService;
            _locationAppService = locationAppService;
            _provinceAppService = provinceAppService;
        }

         public async Task<ActionResult> Index(SearchViewModel model)
           {
               await GetCategoriesDropdown();
               await GetProvinceDropdown();
               await GetLocationsDropdown();
               //SearchViewModel model = new SearchViewModel();
            //return SearchView(new SearchViewModel())
                model.Stores = new List<StoreDto>();
                var output = await _storeAppService.GetStores(null, false);
                model.Stores = output;
                //return  Json(model);
            return View(model);   
           } 

      /*  public async Task<JsonResult> Index(SearchViewModel model)
        {
            try
            {
                model.Stores = new List<StoreDto>();
                var output = await _storeAppService.GetStores(6, 5, false);
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
        } */

        [HttpPost]
        public virtual async Task<JsonResult> Result(SearchViewModel model)
        {
            try
            {
                model.Stores = new List<StoreDto>();
                var output = await _storeAppService.GetStores(model.CategoryValue, model.LocationValue, false);
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
        public async Task GetProvinceDropdown()
        {
            try
            {
                List<Province> prov = new List<Province>();
                var output = await _provinceAppService.GetProvinces(null, false);
                for (int i = 0; i < output.Count(); i++)
                {
                    prov.Add(new Province() { text = output[i].Description, parentId = output[i].Id.ToString() });
                }
                ViewData["provinces"] = prov;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GetCategoriesDropdown()
        {
            try
            {
                var output = await _categoryAppService.GetCategories(null, false);
                ViewData["categories"] = output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GetLocationsDropdown()
        {
            try
            {
                List<Location> loc = new List<Location>();
                var output = await _locationAppService.GetLocations(null, null, false);
                for (int i = 0; i < output.Count(); i++)
                {
                    loc.Add(new Location() { text = output[i].Description, parentId = output[i].ProvinceId.ToString(), value = output[i].Id.ToString() });
                }
                ViewData["locations"] = loc;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
    }

   
}