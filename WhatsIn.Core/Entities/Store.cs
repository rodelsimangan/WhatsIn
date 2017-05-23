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
        public virtual long UserId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string LogoPath { get; set; }
        public virtual string ContactNum { get; set; }
        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string Town { get; set; }
        public virtual int LocationId { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Email { get; set; }
        public virtual string Schedule { get; set; }
        public virtual string FacebookPage { get; set; }
        public virtual string TwitterPage { get; set; }
        public virtual string InstagramPage { get; set; }
    }
}
