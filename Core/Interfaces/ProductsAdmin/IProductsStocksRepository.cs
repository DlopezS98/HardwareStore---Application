using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.ProductsAdmin;
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
        List<ProductStocksDto> GetProductStocks(string Search, bool Available, DateTime StartDate, DateTime EndDate);
        List<StocksDetailsDto> GetProductStocksDetails(string LotNumber, string Search, int WarehouseId);
        StocksDetailsDto GetStocksDetail(string StocksCode);
        void UpdateStocksDetails(List<StocksUpdateDto> dto);
    }
}
