using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using Abp.Web.Mvc.Authorization;

using WhatsIn.Application.Services;
using WhatsIn.Application.Dto;
using WhatsIn.Web.Models;

namespace WhatsIn.Web.Controllers
{
    public class DetailController : WhatsInControllerBase
    {
        private readonly IStoreAppService _storeAppService;
        private readonly ILocationAppService _locationAppService;
        private readonly IProvinceAppService _provinceAppService;

        public DetailController(IStoreAppService appService, ILocationAppService locationAppService, IProvinceAppService provinceAppService)
        {
            _storeAppService = appService;
            _locationAppService = locationAppService;
            _provinceAppService = provinceAppService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                await GetProvinceDropdown();
                ViewData["locations"] = new List<LocationDto>();
                StoreViewModel model = new StoreViewModel(new StoreDto());
                var output = await _storeAppService.GetStoreByUser(AbpSession.UserId.Value);
                model = new StoreViewModel(output);
                return View(model);
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
                var output = await _provinceAppService.GetProvinces(null, false);
                ViewData["provinces"] = output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GetLocationsDropdown(int? provinceId)
        {
            try
            {
                if (provinceId.HasValue)
                {
                    var output = await _locationAppService.GetLocations(provinceId, null, false);
                    ViewData["locations"] = output;
                }
                else
                {
                    ViewData["locations"] = new List<LocationDto>();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> _LocationsDropdown(int? provinceId)
        {
            try
            {
                if (provinceId.HasValue)
                {
                    var output = await _locationAppService.GetLocations(provinceId, null, false);
                    ViewData["locations"] = output;
                }
                else
                {
                    ViewData["locations"] = new List<LocationDto>();
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}