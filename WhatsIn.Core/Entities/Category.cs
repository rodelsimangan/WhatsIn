using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatsIn.Core.Entities
{
    public class Category : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
