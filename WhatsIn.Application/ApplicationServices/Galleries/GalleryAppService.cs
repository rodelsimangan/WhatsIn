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

    public class GalleryAppService : WhatsInAppServiceBase, IGalleryAppService
    {
        private readonly IRepository<Gallery, long> _galleryRepository;

        public GalleryAppService(IRepository<Gallery, long> galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        public async Task DeleteGallery(long id)
        {
            try
            {
                if (id > 0)
                {
                    var gallery = await _galleryRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                    gallery.IsDeleted = true;
                    await _galleryRepository.UpdateAsync(gallery);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<GalleryDto>> GetGalleries(long userId, bool isDeleted)
        {
            try
            {
                var users = await Task.Run(() =>
                {
                    var query = from q in _galleryRepository.GetAll()
                                where q.UserId == userId
                                      && q.IsDeleted == isDeleted
                                select q;

                    return query.ToList();
                });
                return users.MapTo<List<GalleryDto>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GalleryDto> GetGallery(long id)
        {
            try
            {
                var query = await _galleryRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                var dto = query.MapTo<GalleryDto>();
                dto.IsEditMode = true;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpsertGallery(GalleryDto input)
        {
            try
            {
                var obj = input.MapTo<Gallery>();
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
                await _galleryRepository.InsertOrUpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
