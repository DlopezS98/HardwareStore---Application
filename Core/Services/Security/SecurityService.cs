using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Security;
using HardwareStore.Core.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly IUsersRepository UserRepository;
        public SecurityService(IUsersRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }
        public LoginResponse UserLogin(UserDto user)
        {
            try
            {
                UserDto dto = new UserDto();
                dto = this.UserRepository.UserLogin(user);
                return new LoginResponse() { Title = "¡Exitoso!", Message = "Inicio de sesión exitoso", Success = true, User = dto };
            }
            catch (Exception exc)
            {

                return new LoginResponse() { Title = "¡Ha ocurrido un error!", Message = exc.Message, Success = false };
            }
        }
    }
}
