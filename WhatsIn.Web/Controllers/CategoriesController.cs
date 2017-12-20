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
    public class CategoriesController : WhatsInControllerBase
    {
        private readonly ICategoryAppService _appService;

        public CategoriesController(ICategoryAppService appService)
        {
            _appService = appService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _appService.GetCategories(null, false);
            return View(output);
        }

        public async Task<PartialViewResult> UpsertCategoryModal(long? id)
        {
            CategoryViewModel model = new CategoryViewModel(new CategoryDto());
            if (id.HasValue)
            {
                var dto = await _appService.GetCategory(id.Value);
                model = new CategoryViewModel(dto);
            }
            return PartialView("_UpsertCategoryModal", model);
        }
    }
}