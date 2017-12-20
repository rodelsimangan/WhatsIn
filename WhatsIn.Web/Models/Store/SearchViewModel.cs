using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Application.Dto;

namespace WhatsIn.Web.Models
{
    public class SearchViewModel
    {
        public int CategoryValue { get; set; }
        public int ProvinceValue { get; set; }
        public int LocationValue { get; set; }
        public List<StoreDto> Stores { get; set; }
    }
}