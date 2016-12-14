using System.Threading.Tasks;
using Abp.Application.Services;
using WhatsIn.Roles.Dto;

namespace WhatsIn.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
