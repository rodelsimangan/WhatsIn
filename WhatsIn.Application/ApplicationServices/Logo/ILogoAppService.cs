using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using WhatsIn.Application.Dto;

namespace WhatsIn.Application.Services
{
    public interface ILogoAppService : IApplicationService
    {
        Task<List<LogoDto>> GetLogos(string filter, bool isDeleted);
        Task<LogoDto> GetLogo(long id);
        Task UpsertLogo(LogoDto input);
        Task DeleteLogo(long id);
    }
}
