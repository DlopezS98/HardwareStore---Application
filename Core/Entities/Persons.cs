using HardwareStore.Core.Entities.Catalogs;
using HardwareStore.Core.Entities.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities
{
    public class Persons : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string CardId { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Vendors> Vendors { get; set; }
    }
}
