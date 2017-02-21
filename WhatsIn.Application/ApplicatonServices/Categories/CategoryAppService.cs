using Abp.Domain.Repositories;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsIn.Application.Dto;
using WhatsIn.Core.Entities;

namespace WhatsIn.ApplicatonServices
{

    public class CategoryAppService : WhatsInAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category, long> _categoryRepository;

        public CategoryAppService(IRepository<Category, long> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task DeleteCategory(long id)
        {
            try
            {
                if (id > 0)
                {
                    var category = await _categoryRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                    await _categoryRepository.DeleteAsync(category);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<List<CategoryDto>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task UpsertCategory(CategoryDto input)
        {
            throw new NotImplementedException();
        }
    }
}
