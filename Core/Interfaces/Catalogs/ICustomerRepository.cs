using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Catalogs
{
    public interface ICustomerRepository
    {
        List<CustomersDropDto> GetCustomersForDropDownList();
        void CreateNewCustomer(Customers customer);
    }
}
