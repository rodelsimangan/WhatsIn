using Abp.Authorization;
using WhatsIn.Authorization.Roles;
using WhatsIn.MultiTenancy;
using WhatsIn.Users;

namespace WhatsIn.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
