using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Entities.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Catalogs
{
    public interface ISuppliersRepository
    {
        List<SuppliersDropDto> ListSuppliersForDropDowns();
        List<SuppliersDto> GetSuppliers(string search);
        void CreateSupplier(Suppliers suppliers);
        void UpdateSupplier(int Id, SuppliersDto suppliers);
        void DeleteSupplier(int Id, string username);
    }
}
