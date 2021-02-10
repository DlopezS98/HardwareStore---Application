using HardwareStore.Core.DTOs.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs
{
    public class LoginResponse: Response
    {
        public UserDto User { get; set; }
    }
}
