using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using WhatsIn.Authorization.Roles;
using WhatsIn.MultiTenancy;
using WhatsIn.Users;
using WhatsIn.Core.Entities;

namespace WhatsIn.EntityFramework
{
    public class WhatsInDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Location> Locations { get; set; }
        public virtual IDbSet<Province> Provinces { get; set; }
        public virtual IDbSet<Store> Stores { get; set; }
        public virtual IDbSet<Logo> Logos { get; set; }
        public virtual IDbSet<Promotion> Promotions { get; set; }
        public virtual IDbSet<Gallery> Galleries { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public WhatsInDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in WhatsInDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of WhatsInDbContext since ABP automatically handles it.
         */
        public WhatsInDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public WhatsInDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
