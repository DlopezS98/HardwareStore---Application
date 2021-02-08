using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareStore.Core.Entities.Enums;

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
        List<RemovedProductsDto> GetRemovedProducts(DateTime StartDate, DateTime EndDate, string Search);

        Response CreatePendingTransfer(PendingTranfersModelDto dto);
        Response UpdatePendingTranfer(string Code, PendingTranfersModelDto dto);
        Response DeleteProductFromTransferList(string Code, string User);
        List<PendingTranfersDto> GetPendingTransferProducts(string Search, TransferStatus Status);
        PendingTranfersDto GetPendingTransferProduct(string Code);

        //Response CreateTranfer(List<PendingTranfersDto> list, string User);
        //Response CreateTranfersDetails(List<PendingTranfersDto> list);
        Response GenerateTransferTransaction(List<PendingTranfersDto> list, string User);
        List<PendingTranfersDto> ListTransfers(string Search);
    }
}
