using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsIn.Application.Dto;

namespace WhatsIn.Web.Models
{
    [AutoMap(typeof(CategoryDto))]
    public class CategoryViewModel : CategoryDto
    {
        public CategoryViewModel(CategoryDto output)
        {
            output.MapTo(this);
        }
    }
}