using WhatsIn.EntityFramework;
using EntityFramework.DynamicFilters;

namespace WhatsIn.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly WhatsInDbContext _context;

        public InitialHostDbBuilder(WhatsInDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
