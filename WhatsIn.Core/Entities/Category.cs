using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatsIn.Core.Entities
{
    [Table("Categories")]
    public class Category : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
