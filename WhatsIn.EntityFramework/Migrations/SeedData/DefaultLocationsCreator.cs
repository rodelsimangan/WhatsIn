using System.Linq;
using WhatsIn.EntityFramework;
using WhatsIn.MultiTenancy;
using WhatsIn.Core.Entities;

namespace WhatsIn.Migrations.SeedData
{
    public class DefaultLocationsCreator
    {
        private readonly WhatsInDbContext _context;

        public DefaultLocationsCreator(WhatsInDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateProvinceAndLocations();
        }

        private void CreateProvinceAndLocations()
        {
            //Default tenant

            var cavite = _context.Provinces.FirstOrDefault(t => t.Name == "Cavite");
            if (cavite == null)
            {
                cavite =  _context.Provinces.Add(new Province { Name = "Cavite", Description = "Cavite"});
                _context.SaveChanges();

                _context.Locations.Add(new Location { Name = "Carmona", Description = "Carmona", ProvinceId = cavite.Id });
                _context.SaveChanges();
            }
        }
    }
}
