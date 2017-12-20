using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Application.Dto;

namespace WhatsIn.Web.Models
{
    [AutoMap(typeof(LogoDto))]
    public class LogoViewModel : LogoDto
    {
        public LogoViewModel(LogoDto output)
        {
            output.MapTo(this);
        }
    }
}