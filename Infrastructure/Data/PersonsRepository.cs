using HardwareStore.Core.Entities;
using HardwareStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data
{
    public class PersonsRepository : EntityRepository, IPersonsRepository
    {
        private readonly ApplicationContext _dbContext;
        public PersonsRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public int CreateNewPerson(Persons person)
        {
            try
            {
                int LastIndentity = 0;
                SqlParameter firstname = new SqlParameter("@FirstName", SqlDbType.VarChar); firstname.Direction = ParameterDirection.Input;
                SqlParameter lastname = new SqlParameter("@LastName", SqlDbType.VarChar); firstname.Direction = ParameterDirection.Input;
                SqlParameter emailaddress = new SqlParameter("@EmailAddress", SqlDbType.VarChar); firstname.Direction = ParameterDirection.Input;
                SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar); firstname.Direction = ParameterDirection.Input;
                SqlParameter cardid = new SqlParameter("@CardId", SqlDbType.VarChar); firstname.Direction = ParameterDirection.Input;
                SqlParameter phonenumber = new SqlParameter("@PhoneNumber", SqlDbType.VarChar); firstname.Direction = ParameterDirection.Input;

                firstname.Value = person.FirstName;
                lastname.Value = person.LastName;
                emailaddress.Value = person.EmailAddress;
                address.Value = person.Address;
                cardid.Value = person.CardId;
                phonenumber.Value = person.PhoneNumber;

                LastIndentity = this._dbContext.Database
                    .SqlQuery<int>("[dbo].[Sp_CreatePerson] @FirstName, @LastName, @EmailAddress, @Address, @CardId, @PhoneNumber",
                                                            firstname, lastname, emailaddress, address, cardid, phonenumber)
                                                            .FirstOrDefault();

                return LastIndentity;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void UpdatePersonInformation(int Id, Persons person)
        {
            try
            {
                Persons data = this._dbContext.Persons.FirstOrDefault(x => x.Id == Id);
                data.FirstName = person.FirstName;
                data.LastName = person.LastName;
                data.EmailAddress = person.EmailAddress;
                data.Address = person.Address;
                data.CardId = person.CardId;
                data.PhoneNumber = person.PhoneNumber;
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
