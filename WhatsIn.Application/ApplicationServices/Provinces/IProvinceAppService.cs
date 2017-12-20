using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using WhatsIn.Application.Dto;

namespace WhatsIn.Application.Services
{
    public interface IProvinceAppService : IApplicationService
    {
        Task<List<ProvinceDto>> GetProvinces(string filter, bool isDeleted);
        Task<ProvinceDto> GetProvince(long id);
        Task UpsertProvince(ProvinceDto input);
        Task DeleteProvince(long id);
    }
}
