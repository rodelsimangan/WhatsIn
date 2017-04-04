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

    public class LogoAppService : WhatsInAppServiceBase, ILogoAppService
    {
        private readonly IRepository<Logo, long> _logoRepository;

        public LogoAppService(IRepository<Logo, long> logoRepository)
        {
            _logoRepository = logoRepository;
        }

        public async Task DeleteLogo(long id)
        {
            try
            {
                if (id > 0)
                {
                    var logo = await _logoRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                    //await _logoRepository.DeleteAsync(logo);
                    logo.IsDeleted = true;
                    await _logoRepository.UpdateAsync(logo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<LogoDto>> GetLogos(string filter, bool isDeleted)
        {
            try
            {
                var users = await Task.Run(() =>
                {
                    var query = from q in _logoRepository.GetAll()
                                where (string.IsNullOrEmpty(filter) || (q.LogoPath.Contains(filter)))
                                      && q.IsDeleted == isDeleted
                                select q;

                    return query.ToList();
                });
                return users.MapTo<List<LogoDto>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LogoDto> GetLogo(long id)
        {
            try
            {
                var query = await _logoRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                var dto = query.MapTo<LogoDto>();
                dto.IsEditMode = true;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpsertLogo(LogoDto input)
        {
            try
            {
                var obj = input.MapTo<Logo>();
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
                await _logoRepository.InsertOrUpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
