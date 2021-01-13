using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Providers
{
    public class Vendors : BaseEntity
    {
        public int PersonId { get; set; }
        public int SupplierId { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        public virtual Persons Persons { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
