using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.SysConfiguration
{
    public class Configurations
    {
        public int Id { get; set; }
        public int ContactInfoId { get; set; }
        public string BusinessName { get; set; }
        public string OwnerName { get; set; }
        public string RucNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }
    }
}
