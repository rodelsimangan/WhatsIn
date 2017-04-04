using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatsIn.Core.Entities
{
    [Table("Logo")]
    public class Logo : EntityBase
    {
        public virtual int StoreId { get; set; }
        public virtual string LogoPath { get; set; }
    }
}
