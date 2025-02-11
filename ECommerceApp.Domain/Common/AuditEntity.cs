using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Common
{
    public abstract class AuditEntity
    {

        protected AuditEntity()
        {
            this.CreatedAt = DateTime.Now;
            this.Deleted = false;
        }

        public int CreationUser { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? UserMod { get; set; }
        public int? UserDeleted { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
