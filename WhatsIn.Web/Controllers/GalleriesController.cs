using System;
using System.IO;
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
    public class GalleriesController : WhatsInControllerBase
    {
        private readonly IGalleryAppService _appService;

        public GalleriesController(IGalleryAppService appService)
        {
            _appService = appService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _appService.GetGalleries(null, false);
            return View(output);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PartialViewResult> UpsertGalleryModal(long? id)
        {
            GalleryViewModel model = new GalleryViewModel(new GalleryDto());
            if (id.HasValue)
            {
                var dto = await _appService.GetGallery(id.Value);
                model = new GalleryViewModel(dto);
            }
            return PartialView("_UpsertGalleryModal", model);
        }

        // GET: Mpa/MasterData/PostalCodes
        public ActionResult UploadImageGallery(IEnumerable<HttpPostedFileBase> files)
        {
            var reportingLogo = GetBytes(files.First());
            Session["ReportingLogo"] = reportingLogo;
            return null;
        }

        private byte[] GetBytes(HttpPostedFileBase image)
        {
            byte[] returnedByte = null;

            if (image != null)
            {
                var length = image.ContentLength;
                returnedByte = new byte[length];
                image.InputStream.Read(returnedByte, 0, length);
            }

            return returnedByte;
        }
    }
}