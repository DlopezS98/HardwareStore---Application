using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Catalogs
{
    public class Brands : BaseEntity
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Code { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
    }
}
