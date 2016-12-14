using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using WhatsIn.EntityFramework;

namespace WhatsIn.Migrator
{
    [DependsOn(typeof(WhatsInDataModule))]
    public class WhatsInMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<WhatsInDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}