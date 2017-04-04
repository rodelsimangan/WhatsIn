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
    public class PromotionsController : WhatsInControllerBase
    {
        private readonly IPromotionAppService _appService;

        public PromotionsController(IPromotionAppService appService)
        {
            _appService = appService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _appService.GetPromotions(null, false);
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
            return PartialView("_UpsertPromotionModal", model);
        }
    }
}