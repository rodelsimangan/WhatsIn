using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Application.Dto;

namespace WhatsIn.Web.Models
{
    [AutoMap(typeof(ProvinceDto))]
    public class ProvinceViewModel : ProvinceDto
    {
        public ProvinceViewModel(ProvinceDto output)
        {
            output.MapTo(this);
        }
    }
}