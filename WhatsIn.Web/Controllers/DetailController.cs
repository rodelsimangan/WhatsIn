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
        private readonly IStoreAppService _appService;

        public DetailController(IStoreAppService appService)
        {
            _appService = appService;
        }

        public async Task<ActionResult> Index()
        {
            StoreViewModel model = new StoreViewModel(new StoreDto());
            var output = await _appService.GetStoreByUser(AbpSession.UserId.Value);
            model = new StoreViewModel(output);
            return View(model);
        }      
    }
}