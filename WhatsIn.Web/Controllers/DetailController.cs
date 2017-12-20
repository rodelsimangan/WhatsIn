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
using Abp.Web.Models;
using System.IO;
using System.Web.Helpers;

namespace WhatsIn.Web.Controllers
{
    [AbpMvcAuthorize]
    public class DetailController : WhatsInControllerBase
    {
        private readonly IStoreAppService _storeAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly ILocationAppService _locationAppService;
        private readonly IProvinceAppService _provinceAppService;

        public DetailController(IStoreAppService appService, ICategoryAppService categoryAppService, ILocationAppService locationAppService, IProvinceAppService provinceAppService)
        {
            _storeAppService = appService;
            _categoryAppService = categoryAppService;
            _locationAppService = locationAppService;
            _provinceAppService = provinceAppService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                await GetCategoriesDropdown();
                await GetProvinceDropdown();
                await GetLocationsDropdown();
                //ViewData["locations"] = new List<LocationDto>();
                StoreViewModel model = new StoreViewModel(new StoreDto());
                var output = await _storeAppService.GetStoreByUser(AbpSession.UserId.Value);

                model = new StoreViewModel(output);
                LocationDto loc = new LocationDto();
                if (output.LocationId > 0)
                {
                    loc = await _locationAppService.GetLocation(Convert.ToInt32(output.LocationId));
                    model.ProvinceId = Convert.ToInt32(loc.ProvinceId);
                }                
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

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            string _comPath = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    _comPath = string.Concat(Server.MapPath("/Uploads/Logos/"), AbpSession.UserId.Value, "_", _imgname, _ext);
                    _imgname = string.Concat(AbpSession.UserId.Value, "_", _imgname, _ext);

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                        img.Resize(200, 200);
                    img.Save(_comPath);
                    // end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
            //return Json(Convert.ToString(_comPath), JsonRequestBehavior.AllowGet);
        }
    }

    public class Province
    {
        public string text { get; set; }
        public string parentId { get; set; }

    }
    public class Location
    {
        public string text { get; set; }
        public string value { get; set; }
        public string parentId { get; set; }

    }
}