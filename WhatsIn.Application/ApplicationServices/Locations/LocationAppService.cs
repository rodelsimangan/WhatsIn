using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using WhatsIn.Application.Dto;
using WhatsIn.Core.Entities;


namespace WhatsIn.Application.Services
{

    public class LocationAppService : WhatsInAppServiceBase, ILocationAppService
    {
        private readonly IRepository<Location, long> _locationRepository;

        public LocationAppService(IRepository<Location, long> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task DeleteLocation(long id)
        {
            try
            {
                if (id > 0)
                {
                    var location = await _locationRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                    location.IsDeleted = true;
                    await _locationRepository.UpdateAsync(location);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LocationDto>> GetLocations(long provinceId, string filter, bool isDeleted)
        {
            try
            {
                var users = await Task.Run(() =>
            {
                var query = from q in _locationRepository.GetAll()
                            where (string.IsNullOrEmpty(filter) || (q.Description.Contains(filter) || q.Name.Contains(filter)))
                                  && q.ProvinceId == provinceId && q.IsDeleted == isDeleted
                            select q;

                return query.ToList();
            });
                users.ForEach(i => i.ProvinceId = provinceId);
                return users.MapTo<List<LocationDto>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LocationDto> GetLocation(long id)
        {
            try
            {
                var query = await _locationRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                var dto = query.MapTo<LocationDto>();
                dto.IsEditMode = true;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpsertLocation(LocationDto input)
        {
            try
            {
                var obj = input.MapTo<Location>();
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
                await _locationRepository.InsertOrUpdateAsync(obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
