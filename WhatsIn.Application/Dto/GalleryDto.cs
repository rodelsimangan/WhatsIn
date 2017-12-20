using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.AutoMapper;
using WhatsIn.Core.Entities;

namespace WhatsIn.Application.Dto
{
    [AutoMap(typeof(Gallery))]
    public class GalleryDto : DtoBase
    {
        public long UserId { get; set; }
        public int StoreId { get; set; }
        public string GalleryPath { get; set; }
    }
}
