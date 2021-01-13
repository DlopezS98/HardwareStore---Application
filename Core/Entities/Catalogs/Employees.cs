using HardwareStore.Core.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Catalogs
{
    public class Employees
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Initials { get; set; }
        public string Code { get; set; }
        public string Position { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public virtual Persons Persons { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
