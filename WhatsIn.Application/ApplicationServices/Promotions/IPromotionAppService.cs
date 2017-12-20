using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using WhatsIn.Application.Dto;

namespace WhatsIn.Application.Services
{
    public interface IPromotionAppService : IApplicationService
    {
        Task<List<PromotionDto>> GetPromotions(long userId, bool isDeleted);
        Task<PromotionDto> GetPromotion(long id);
        Task UpsertPromotion(PromotionDto input);
        Task DeletePromotion(long id);
    }
}
