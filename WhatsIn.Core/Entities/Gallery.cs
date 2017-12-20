using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatsIn.Core.Entities
{
    [Table("Galleries")]
    public class Gallery : EntityBase
    {
        public virtual long UserId { get; set; }
        public virtual int StoreId { get; set; }
        public virtual string GalleryPath { get; set; }
    }
}
