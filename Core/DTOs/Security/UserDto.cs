using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Security
{
    public class UserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
    }
}
