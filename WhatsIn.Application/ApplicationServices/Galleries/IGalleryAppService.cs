using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using WhatsIn.Application.Dto;

namespace WhatsIn.Application.Services
{
    public interface IGalleryAppService : IApplicationService
    {
        Task<List<GalleryDto>> GetGalleries(long userId, bool isDeleted);
        Task<GalleryDto> GetGallery(long id);
        Task UpsertGallery(GalleryDto input);
        Task DeleteGallery(long id);
    }
}
