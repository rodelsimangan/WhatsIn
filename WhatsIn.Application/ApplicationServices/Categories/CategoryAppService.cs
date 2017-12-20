using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.Domain.Repositories;
using Abp.AutoMapper;
using AutoMapper;

using WhatsIn.Application.Dto;
using WhatsIn.Core.Entities;


namespace WhatsIn.Application.Services
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
                    //await _categoryRepository.DeleteAsync(category);
                    category.IsDeleted = true;
                    await _categoryRepository.UpdateAsync(category);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<CategoryDto>> GetCategories(string filter, bool isDeleted)
        {
            try
            {
                var users = await Task.Run(() =>
                {
                    var query = from q in _categoryRepository.GetAll()
                                where (string.IsNullOrEmpty(filter) || (q.Description.Contains(filter) || q.Name.Contains(filter)))
                                      && q.IsDeleted == isDeleted
                                select q;

                    return query.ToList();
                });
                return users.MapTo<List<CategoryDto>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoryDto> GetCategory(long id)
        {
            try
            {
                var query = await _categoryRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                var dto = query.MapTo<CategoryDto>();
                dto.IsEditMode = true;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpsertCategory(CategoryDto input)
        {
            try
            {
                var obj = input.MapTo<Category>();
                if (input.Id == 0)
                {
                    obj.IsDeleted = false;
                    obj.CreatedBy = AbpSession.UserId;
                    obj.DateCreated = DateTime.Now;
                    obj.DateModified = null;
                }
                else
                {
                    obj.ModifiedBy = AbpSession.UserId;
                    obj.DateModified = DateTime.Now;
                }
                await _categoryRepository.InsertOrUpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
