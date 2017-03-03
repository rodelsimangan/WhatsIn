using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.Domain.Entities;

namespace WhatsIn.Core.Entities
{
    public abstract class EntityBase : Entity<long>
    {
        public override long Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual long? CreatedBy { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual long? ModifiedBy { get; set; }
        public virtual DateTime? DateModified { get; set; }
    }
}
