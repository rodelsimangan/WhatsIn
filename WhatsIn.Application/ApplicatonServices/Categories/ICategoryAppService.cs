using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsIn.Application.Dto;

namespace WhatsIn.ApplicatonServices
{
    public interface ICategoryAppService
    {
        Task<List<CategoryDto>> GetCategories();
        Task UpsertCategory(CategoryDto input);
        Task DeleteCategory(long id);
    }
}
