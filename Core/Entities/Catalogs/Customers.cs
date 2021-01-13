using HardwareStore.Core.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Catalogs
{
    public class Customers
    {
        public int Id { get; set; }
        public Nullable<int> PersonId { get; set; }
        public string Initials { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        public virtual Persons Persons { get; set; }
        public virtual ICollection<SalesInvoices> SalesInvoices { get; set; }
    }
}
