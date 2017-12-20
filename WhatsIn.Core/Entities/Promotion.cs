using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatsIn.Core.Entities
{
    [Table("Promotions")]
    public class Promotion : EntityBase
    {
        public virtual long UserId { get; set; }
        public virtual int StoreId { get; set; }
        public virtual string PromotionPath { get; set; }
    }
}
