using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Security
{
    public interface IUsersRepository
    {
        UserDto UserLogin(UserDto user);
    }
}
