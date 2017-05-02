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

    public class StoreAppService : WhatsInAppServiceBase, IStoreAppService
    {
        private readonly IRepository<Store, long> _storeRepository;

        public StoreAppService(IRepository<Store, long> storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task DeleteStore(long id)
        {
            try
            {
                if (id > 0)
                {
                    var store = await _storeRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                    //await _storeRepository.DeleteAsync(store);
                    store.IsDeleted = true;
                    await _storeRepository.UpdateAsync(store);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<StoreDto>> GetStores(string filter, bool isDeleted)
        {
            try
            {
                var users = await Task.Run(() =>
                {
                    var query = from q in _storeRepository.GetAll()
                                where (string.IsNullOrEmpty(filter) || (q.Description.Contains(filter) || q.Name.Contains(filter)))
                                      && q.IsDeleted == isDeleted
                                select q;

                    return query.ToList();
                });
                return users.MapTo<List<StoreDto>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StoreDto> GetStore(long id)
        {
            try
            {
                var query = await _storeRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                var dto = query.MapTo<StoreDto>();
                dto.IsEditMode = true;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StoreDto> GetStoreByUser(long userId)
        {
            try
            {
                var query = await _storeRepository.GetAll().AsNoTracking().SingleAsync(u => u.UserId == userId);
                var dto = query.MapTo<StoreDto>();
                dto.IsEditMode = true;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpsertStore(StoreDto input)
        {
            try
            {
                var obj = input.MapTo<Store>();
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
                await _storeRepository.InsertOrUpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
