using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using WhatsIn.Application.Dto;

namespace WhatsIn.Application.Services
{
    public interface ICategoryAppService : IApplicationService
    {
        Task<List<CategoryDto>> GetCategories(string filter, bool isDeleted);
        Task<CategoryDto> GetCategory(long id);
        Task UpsertCategory(CategoryDto input);
        Task DeleteCategory(long id);
    }
}
