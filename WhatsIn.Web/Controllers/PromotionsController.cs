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
using System.Web.Helpers;
using Abp.Web.Models;

namespace WhatsIn.Web.Controllers
{
    [AbpMvcAuthorize]
    public class PromotionsController : WhatsInControllerBase
    {
        private readonly IPromotionAppService _appService;

        public PromotionsController(IPromotionAppService appService)
        {
            _appService = appService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _appService.GetPromotions(AbpSession.UserId.Value, false);
            return View(output);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PartialViewResult> UpsertPromotionModal(long? id)
        {
            PromotionViewModel model = new PromotionViewModel(new PromotionDto());
            if (id.HasValue)
            {
                var dto = await _appService.GetPromotion(id.Value);
                model = new PromotionViewModel(dto);                
            }
            else
                model.UserId = AbpSession.UserId.Value;
            return PartialView("_UpsertPromotionModal", model);
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
                    _comPath = string.Concat(Server.MapPath("/Uploads/Promotions/"), AbpSession.UserId.Value, "_", _imgname, _ext);
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
}