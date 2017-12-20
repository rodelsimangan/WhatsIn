using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using WhatsIn.Authorization;
using WhatsIn.Authorization.Roles;
using WhatsIn.EntityFramework;
using WhatsIn.Users;

namespace WhatsIn.Migrations.SeedData
{
    public class TenantRoleAndUserBuilder
    {
        private readonly WhatsInDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(WhatsInDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            //Admin role

            var adminRole = _context.Roles.FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRole == null)
            {
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Admin, StaticRoleNames.Tenants.Admin) { IsStatic = true });
                _context.SaveChanges();

                _context.Permissions.Add(
                    new RolePermissionSetting
                    {
                        TenantId = _tenantId,
                        Name = PermissionNames.Pages,
                        IsGranted = true,
                        RoleId = adminRole.Id
                    });

                _context.Permissions.Add(
                       new RolePermissionSetting
                       {
                           TenantId = _tenantId,
                           Name = PermissionNames.Pages_Users,
                           IsGranted = true,
                           RoleId = adminRole.Id
                       });

                _context.Permissions.Add(
                     new RolePermissionSetting
                     {
                         TenantId = _tenantId,
                         Name = PermissionNames.Pages_Categories,
                         IsGranted = true,
                         RoleId = adminRole.Id
                     });

                _context.Permissions.Add(
                       new RolePermissionSetting
                       {
                           TenantId = _tenantId,
                           Name = PermissionNames.Pages_Locations,
                           IsGranted = true,
                           RoleId = adminRole.Id
                       });

                _context.SaveChanges();
            }

            //admin user

            var adminUser = _context.Users.FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == User.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@defaulttenant.com", "123qwe");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                //Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }
        }
    }
}