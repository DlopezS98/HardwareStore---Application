using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Reports
{
    public interface IReportsService
    {
        List<ProductDetailsDto> ListAllProductDetails();
        List<InvoicesDto> GetPurhaseInvoices(DateTime StartDate, DateTime EndDate, string Search);
        List<InvoiceDetailsDto> GetPurchaseInvoiceDetails(int InvoiceId);
        List<SalesInvoiceDto> ListSalesInvoices(DateTime StartDate, DateTime EndDate, string Search);
        List<SalesDetailsDto> ListSalesDetails(int InvoiceId);
        List<ProductStocksDto> GetProductStocks(string Search, DateTime StartDate, DateTime EndDate);
        List<StocksDetailsDto> GetProductStocksDetails(string LotNumber, string Search, int WarehouseId);
        List<RemovedProductsDto> GetRemovedProducts(DateTime StartDate, DateTime EndDate, string Search); //metodo aun no implementado...
        List<WarehousesDropDto> ListWarehousesForDropDowns(); //Listar bodegas para el dropdownlist de bodegas (filtro por bodega);
    }
}
