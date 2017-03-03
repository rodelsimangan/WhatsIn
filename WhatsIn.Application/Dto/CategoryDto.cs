using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.AutoMapper;
using WhatsIn.Core.Entities;

namespace WhatsIn.Application.Dto
{
    [AutoMap(typeof(Category))]
    public class CategoryDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
