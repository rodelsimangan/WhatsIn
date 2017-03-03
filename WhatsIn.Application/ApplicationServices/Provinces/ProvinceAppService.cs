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

    public class ProvinceAppService : WhatsInAppServiceBase, IProvinceAppService
    {
        private readonly IRepository<Province, long> _provinceRepository;

        public ProvinceAppService(IRepository<Province, long> provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task DeleteProvince(long id)
        {
            try
            {
                if (id > 0)
                {
                    var province = await _provinceRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                    province.IsDeleted = true;
                    await _provinceRepository.UpdateAsync(province);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ProvinceDto>> GetProvinces(string filter, bool isDeleted)
        {
            try
            {
                var users = await Task.Run(() =>
                {
                    var query = from q in _provinceRepository.GetAll()
                                where (string.IsNullOrEmpty(filter) || (q.Description.Contains(filter) || q.Name.Contains(filter)))
                                      && q.IsDeleted == isDeleted
                                select q;

                    return query.ToList();
                });
                return users.MapTo<List<ProvinceDto>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProvinceDto> GetProvince(long id)
        {
            try
            {
                var query = await _provinceRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                var dto = query.MapTo<ProvinceDto>();
                dto.IsEditMode = true;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpsertProvince(ProvinceDto input)
        {
            try
            {
                var obj = input.MapTo<Province>();
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
                await _provinceRepository.InsertOrUpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
