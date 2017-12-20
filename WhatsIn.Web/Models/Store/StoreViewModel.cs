using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Application.Dto;

namespace WhatsIn.Web.Models
{
    [AutoMap(typeof(StoreDto))]
    public class StoreViewModel : StoreDto
    {
        public int ProvinceId { get; set; }
        public StoreViewModel(StoreDto output)
        {
            output.MapTo(this);
        }
    }
}