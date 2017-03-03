using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using WhatsIn.Application.Dto;

namespace WhatsIn.Application.Services
{
    public interface ILocationAppService : IApplicationService
    {
        Task<List<LocationDto>> GetLocations(long provinceId, string filter, bool isDeleted);
        Task<LocationDto> GetLocation(long id);
        Task UpsertLocation(LocationDto input);
        Task DeleteLocation(long id);
    }
}
