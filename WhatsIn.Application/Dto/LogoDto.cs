using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.AutoMapper;
using WhatsIn.Core.Entities;

namespace WhatsIn.Application.Dto
{
    [AutoMap(typeof(Promotion))]
    public class PromotionDto : DtoBase
    {
        public int StoreId { get; set; }
        public string PromotionPath { get; set; }
    }
}
