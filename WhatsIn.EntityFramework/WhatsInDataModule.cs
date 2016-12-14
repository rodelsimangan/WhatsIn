using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using WhatsIn.EntityFramework;

namespace WhatsIn
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(WhatsInCoreModule))]
    public class WhatsInDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<WhatsInDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
