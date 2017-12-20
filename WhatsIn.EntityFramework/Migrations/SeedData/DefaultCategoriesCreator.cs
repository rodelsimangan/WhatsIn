using System.Linq;
using WhatsIn.EntityFramework;
using WhatsIn.MultiTenancy;
using WhatsIn.Core.Entities;

namespace WhatsIn.Migrations.SeedData
{
    public class DefaultCategoriesCreator
    {
        private readonly WhatsInDbContext _context;

        public DefaultCategoriesCreator(WhatsInDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCategories();
        }

        private void CreateCategories()
        {
            //Default tenant

            var fastfood = _context.Categories.FirstOrDefault(t => t.Name == "Fastfood");
            if (fastfood == null)
            {
                _context.Categories.Add(new Category { Name = "Fastfood", Description = "Fastfood" });
                _context.SaveChanges();                
            }
        }
    }
}
