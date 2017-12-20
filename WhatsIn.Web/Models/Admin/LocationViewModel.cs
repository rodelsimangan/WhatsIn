using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Application.Dto;

namespace WhatsIn.Web.Models
{
    [AutoMap(typeof(LocationDto))]
    public class LocationViewModel : LocationDto
    {
        public LocationViewModel(LocationDto output)
        {
            output.MapTo(this);
        }
    }
}