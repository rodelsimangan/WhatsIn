using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Application.Dto;

namespace WhatsIn.Web.Models
{
    [AutoMap(typeof(PromotionDto))]
    public class PromotionViewModel : PromotionDto
    {
        public PromotionViewModel(PromotionDto output)
        {
            output.MapTo(this);
        }
    }
}