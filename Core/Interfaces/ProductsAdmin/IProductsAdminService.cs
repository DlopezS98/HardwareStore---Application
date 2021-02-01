using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.ProductsAdmin
{
    public interface IProductsAdminService
    {
        List<ProductStocksDto> ListProductStocks(string Search, bool Available, DateTime StartDate, DateTime EndDate);
        List<StocksDetailsDto> ListStocksDetails(string LotNumber, string Search, int WarehouseId);
        StocksDetailsDto GetAStocksDetail(string StocksCode);
        List<WarehousesDropDto> ListWarehousesForDropDowns();
        List<MeasureUnitsDropDto> ListMeasureUnitForDropdownsByType(int TypeId);
        Response DeleteProductFromStocks(DeleteProductDto dto);
    }
}
