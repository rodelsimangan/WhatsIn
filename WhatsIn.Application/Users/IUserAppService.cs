using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using WhatsIn.Users.Dto;

namespace WhatsIn.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        Task<ListResultDto<UserListDto>> GetUsers();

        Task UpsertUser(UserInputDto input);

        Task<UserInputDto> GetUser(long id);
    }
}