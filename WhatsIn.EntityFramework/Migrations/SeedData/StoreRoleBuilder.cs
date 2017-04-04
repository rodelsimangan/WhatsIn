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
    public class StoreRoleBuilder
    {
        private readonly WhatsInDbContext _context;
        private readonly int _tenantId;

        public StoreRoleBuilder(WhatsInDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateStoreRole();
        }

        private void CreateStoreRole()
        {
            //Store role

            var storeRole = _context.Roles.FirstOrDefault(r => r.TenantId == _tenantId && r.Name == StaticRoleNames.Tenants.Store);
            if (storeRole == null)
            {
                storeRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Tenants.Store, StaticRoleNames.Tenants.Store) { IsStatic = true });
                _context.SaveChanges();

                //Grant all permissions to admin role
                var permissions = PermissionFinder
                    .GetAllPermissions(new WhatsInAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            TenantId = _tenantId,
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = storeRole.Id
                        });
                }

                _context.SaveChanges();
            }           
        }
    }
}