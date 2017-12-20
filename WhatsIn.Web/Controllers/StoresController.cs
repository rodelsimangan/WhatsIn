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
    [AbpMvcAuthorize]
    public class StoresController : WhatsInControllerBase
    {
        private readonly IStoreAppService _appService;

        public StoresController(IStoreAppService appService)
        {
            _appService = appService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _appService.GetStores(null, false);
            return View(output);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PartialViewResult> UpsertStoreModal(long? id)
        {
            StoreViewModel model = new StoreViewModel(new StoreDto());
            if (id.HasValue)
            {
                var dto = await _appService.GetStore(id.Value);
                model = new StoreViewModel(dto);
            }
            return PartialView("_UpsertStoreModal", model);
        }
    }
}