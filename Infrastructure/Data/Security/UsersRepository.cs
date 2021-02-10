using HardwareStore.Core.DTOs.Security;
using HardwareStore.Core.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Security
{
    public class UsersRepository : EntityRepository, IUsersRepository
    {
        private readonly ApplicationContext _dbContext;
        public UsersRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public UserDto UserLogin(UserDto user)
        {
            try
            {
                UserDto dto = new UserDto();
                int UserId = this.VerifyUserNameExist(user.UserName);
                this.VerifyPassword(UserId, user.Password);
                dto = this.GetUser(UserId);
                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private bool VerifyPassword(int UserId, string password)
        {
            try
            {
                var list = this._dbContext.Users.Where(x => x.Deleted == false).ToList();
                var user = list.FirstOrDefault(x => x.Id == UserId);
                var resp = user.Password == password ? true : throw new Exception("La contraseña es incorrecta"); ;
                return resp;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private int VerifyUserNameExist(string userName)
        {
            try
            {
                var user = this.GetUsers().FirstOrDefault(x => x.UserName == userName || x.EmailAddress == userName);
                if (user != null)
                    return user.UserId;

                throw new Exception("El nombre de usuario es incorrecto");
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private List<UserDto> GetUsers(string Search, int RoleId)
        {
            try
            {
                List<UserDto> list = new List<UserDto>();
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter roleid = new SqlParameter("@RoleId", SqlDbType.Int); roleid.Direction = ParameterDirection.Input;
                search.Value = Search;
                roleid.Value = RoleId;
                list = this._dbContext.Database.SqlQuery<UserDto>("EXEC [dbo].[Sp_ListUsers] @Search, @RoleId", search, roleid).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private List<UserDto> GetUsers()
        {
            try
            {
                List<UserDto> list = new List<UserDto>();
                list = this.GetUsers("", 0);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private UserDto GetUser(int Id)
        {
            try
            {
                UserDto dto = new UserDto();
                dto = this.GetUsers().FirstOrDefault(x => x.UserId == Id);
                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
