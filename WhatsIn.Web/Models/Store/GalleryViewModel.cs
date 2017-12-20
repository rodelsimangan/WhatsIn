using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Application.Dto;

namespace WhatsIn.Web.Models
{
    [AutoMap(typeof(GalleryDto))]
    public class GalleryViewModel : GalleryDto
    {
        public GalleryViewModel(GalleryDto output)
        {
            output.MapTo(this);
        }
    }
}