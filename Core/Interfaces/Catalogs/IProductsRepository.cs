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
        ProductDetailsDto GetAProductDetail(string Code);
        List<ProductDetailsDto> ListAllProductDetails();
        DataTable GetProductDetailsFromDatabase(bool Deleted, string Search);
    }
}
