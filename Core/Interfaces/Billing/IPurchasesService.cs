using HardwareStore.Core.DTOs.Products;
using HardwareStore.Core.DTOs.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Billing
{
    public interface IPurchasesService
    {
        List<ProductDetailsDto> GetProductDetails(Boolean Deleted, string Search);
        List<WarehousesDropDto> GetWarehousesForDropdowns();
    }
}
