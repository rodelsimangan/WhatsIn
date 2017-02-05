using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using WhatsIn.Authorization;
using WhatsIn.Users;
using WhatsIn.Users.Dto;
using WhatsIn.Web.Models;

namespace WhatsIn.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : WhatsInControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }

        public async Task<PartialViewResult> UpsertUserModal(long? id)
        {
            UserInputViewModel model = new UserInputViewModel(new UserInputDto());
            if (id.HasValue)
            {
                var dto = await _userAppService.GetUser(id.Value);
                model = new UserInputViewModel(dto);
            }
            return PartialView("_UpsertUserModal", model);
        }
    }
}