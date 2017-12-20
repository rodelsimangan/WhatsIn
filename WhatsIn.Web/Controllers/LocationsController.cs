using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using Abp.Web.Mvc.Authorization;
using Abp.AutoMapper;

using WhatsIn.Application.Services;
using WhatsIn.Application.Dto;
using WhatsIn.Web.Models;

namespace WhatsIn.Web.Controllers
{
    [AbpMvcAuthorize]
    public class LocationsController : WhatsInControllerBase
    {
        private readonly ILocationAppService _locationAppService;
        private readonly IProvinceAppService _provinceAppService;

        public LocationsController(ILocationAppService locationAppService, IProvinceAppService provinceAppService)
        {
            _locationAppService = locationAppService;
            _provinceAppService = provinceAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _provinceAppService.GetProvinces(null, false);
            return View(output);
        }

        public async Task<PartialViewResult> UpsertProvinceModal(long? id)
        {
            ProvinceViewModel model = new ProvinceViewModel(new ProvinceDto());
            if (id.HasValue)
            {
                var dto = await _provinceAppService.GetProvince(id.Value);
                model = new ProvinceViewModel(dto);
            }
            return PartialView("_UpsertProvinceModal", model);
        }

        /*   public async Task<ActionResult> GetLocations(int provinceId)
           {
               var output = await _locationAppService.GetLocations(provinceId , null, false);
               return View(output);
           } */

        public async Task<PartialViewResult> GetLocations(long? provinceId)
        {
            //List<LocationViewModel> list = new List<LocationViewModel>();// (new LocationDto())>;
            try
            {
                var output = await _locationAppService.GetLocations(provinceId.Value, null, false);
                ViewData["provinceId"] = provinceId;
                return PartialView("_Locations", output);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PartialViewResult> UpsertLocationModal(long? id, long? provinceId)
        {
            LocationViewModel model = new LocationViewModel(new LocationDto());
            if (id.HasValue)
            {
                var dto = await _locationAppService.GetLocation(id.Value);
                model = new LocationViewModel(dto);
            }
            else
            {
                if (provinceId.HasValue)
                    model.ProvinceId = provinceId.Value;
            }
            return PartialView("_UpsertLocationModal", model);
        }
    }
}