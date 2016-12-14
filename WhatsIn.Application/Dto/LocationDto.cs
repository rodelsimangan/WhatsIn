using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.AutoMapper;
using WhatsIn.Core.Entities;

namespace WhatsIn.Application.Dto
{
    [AutoMapFrom(typeof(Location))]
    public class LocationDto : DtoBase
    {
        public long ProvinceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
