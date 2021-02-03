using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Reports
{
    public interface IReportsService
    {
        DataTable GetProductDetailsFromDatabase(bool Deleted, string Search);
        DataTable GetPurhaseInvoices(DateTime StartDate, DateTime EndDate, string Search);
        DataTable GetPurchaseInvoiceDetails(int InvoiceId);
        DataTable ListSalesInvoices(DateTime StartDate, DateTime EndDate, string Search);
        DataTable ListSalesDetails(int InvoiceId);
        DataTable GetProductStocks(string Search, DateTime StartDate, DateTime EndDate);
        DataTable GetProductStocksDetails(string LotNumber, string Search, int WarehouseId);
        DataTable GetRemovedProducts(DateTime StartDate, DateTime EndDate, string Search);
        List<WarehousesDropDto> ListWarehousesForDropDowns(); //Listar bodegas para el dropdownlist de bodegas (filtro por bodega);
    }
}
