using System.Linq;
using WhatsIn.EntityFramework;
using WhatsIn.MultiTenancy;

namespace WhatsIn.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly WhatsInDbContext _context;

        public DefaultTenantCreator(WhatsInDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
