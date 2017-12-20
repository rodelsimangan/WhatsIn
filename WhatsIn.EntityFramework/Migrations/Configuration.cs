using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using WhatsIn.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace WhatsIn.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<WhatsIn.EntityFramework.WhatsInDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WhatsIn";
        }

        protected override void Seed(WhatsIn.EntityFramework.WhatsInDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            new StoreRoleBuilder(context, 1).Create();
            new DefaultCategoriesCreator(context).Create();
            new DefaultLocationsCreator(context).Create();
            context.SaveChanges();
        }
    }
}
