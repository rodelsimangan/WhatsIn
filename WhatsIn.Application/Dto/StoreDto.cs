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
        public long UserId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public string ContactNum { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public int LocationId { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Schedule { get; set; }
        public string FacebookPage { get; set; }
        public string TwitterPage { get; set; }
        public string InstagramPage { get; set; }

    }
}
