using HardwareStore.Core.DTOs.Catalogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Catalogs
{
    public interface IProductsRepository
    {
        List<ProductDetailsDto> ListAllProductDetails(Boolean Deleted, string Search);
        List<ProductDetailsDto> ListAllProductDetails();
        DataTable GetProductDetailsFromDatabase(Boolean Deleted, string Search);
    }
}
