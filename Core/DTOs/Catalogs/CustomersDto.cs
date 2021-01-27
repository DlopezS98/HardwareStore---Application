using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Catalogs
{
    public class CustomersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string CardId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
