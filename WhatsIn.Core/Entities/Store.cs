using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatsIn.Core.Entities
{
    [Table("Stores")]
    public class Store : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string LogoPath { get; set; }
        public virtual string ContactNum { get; set; }
        public virtual string Address { get; set; }
        public virtual int LocationId { get; set; }
        public virtual string Email { get; set; }
        public virtual string Schedule { get; set; }
    }
}
