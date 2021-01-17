using HardwareStore.Core.DTOs;
using HardwareStore.Core.Entities.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.ProductsAdmin
{
    public interface IProductsStocksRepository
    {
        void RegisterNewProductStocks(ProductStocks Product);
        void RegisterProductStocksDetails(List<DetailProductStocks> Details);
    }
}
