using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using WhatsIn.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WhatsIn.Web.Controllers
{
    [AbpMvcAuthorize]
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

        public async Task<ActionResult> Index()
        {
            await GetCategoriesDropdown();
            await GetProvinceDropdown();
            await GetLocationsDropdown();
            return View();
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