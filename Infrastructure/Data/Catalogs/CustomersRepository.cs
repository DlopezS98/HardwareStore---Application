using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Entities.Catalogs;
using HardwareStore.Core.Interfaces;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Catalogs
{
    public class CustomersRepository : EntityRepository, ICustomerRepository
    {

        private readonly ApplicationContext _dbContext;
        public CustomersRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void CreateNewCustomer(Customers customer)
        {
            try
            {
                this._dbContext.Customers.Add(customer);
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<CustomersDropDto> GetCustomersForDropDownList()
        {
            try
            {
                List<CustomersDropDto> dto = new List<CustomersDropDto>();
                dto = ( from customer in this._dbContext.Customers
                        join person in this._dbContext.Persons
                        on customer.PersonId equals person.Id
                        where customer.Deleted == false
                        select new CustomersDropDto() {
                            Id = customer.Id,
                            Name = person.FullName
                        }).ToList();
                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
