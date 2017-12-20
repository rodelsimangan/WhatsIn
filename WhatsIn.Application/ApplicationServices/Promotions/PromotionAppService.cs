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

    public class PromotionAppService : WhatsInAppServiceBase, IPromotionAppService
    {
        private readonly IRepository<Promotion, long> _promotionRepository;

        public PromotionAppService(IRepository<Promotion, long> promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task DeletePromotion(long id)
        {
            try
            {
                if (id > 0)
                {
                    var promotion = await _promotionRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                    promotion.IsDeleted = true;
                    await _promotionRepository.UpdateAsync(promotion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<PromotionDto>> GetPromotions(long userId, bool isDeleted)
        {
            try
            {
                var users = await Task.Run(() =>
                {
                    var query = from q in _promotionRepository.GetAll()
                                where q.UserId == userId
                                      && q.IsDeleted == isDeleted
                                select q;

                    return query.ToList();
                });
                return users.MapTo<List<PromotionDto>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PromotionDto> GetPromotion(long id)
        {
            try
            {
                var query = await _promotionRepository.GetAll().AsNoTracking().SingleAsync(u => u.Id == id);
                var dto = query.MapTo<PromotionDto>();
                dto.IsEditMode = true;
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpsertPromotion(PromotionDto input)
        {
            try
            {
                var obj = input.MapTo<Promotion>();
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
                await _promotionRepository.InsertOrUpdateAsync(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
