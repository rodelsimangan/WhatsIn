using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.AutoMapper;
using WhatsIn.Core.Entities;

namespace WhatsIn.Application.Dto
{
    [AutoMap(typeof(Store))]
    public class StoreDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public string ContactNum { get; set; }
        public string Address { get; set; }
        public int LocationId { get; set; }
        public string Email { get; set; }
        public string Schedule { get; set; }
    }
}
