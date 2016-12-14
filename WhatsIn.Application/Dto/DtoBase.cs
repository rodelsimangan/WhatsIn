using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace WhatsIn.Application.Dto
{
    [Serializable]
    public abstract class DtoBase:EntityDto<long>
    {
        public long CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
