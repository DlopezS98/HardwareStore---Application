using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.DTOs.SysConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Billing
{
    public interface ISalesServices
    {
        List<ProductStocksDto> ListProductStocks(string Search, bool Available, DateTime StartDate, DateTime EndDate);
        List<StocksDetailsDto> ListStocksDetails(string LotNumber, string Search, int WarehouseId);
        List<WarehousesDropDto> ListWarehousesForDropDowns();
        List<MeasureUnitsDropDto> ListMeasureUnitForDropdownsByType(int TypeId);
        Response RegisterSaleTransaction(SaleTransactionDto Invoice);
        StocksDetailsDto GetAStocksDetail(string StocksCode);
        List<CustomersDropDto> ListCustomersForDropDownList();
        Response CreateCustomer(string User, CustomersDto customer);
        CurrencyExchangeDto GetACurrencyExchange(int local, int foreign);
        List<ForeignCurrencyDropDto> ListForeignCurrencies();
        LocalCurrencyDropDto GetALocalCurrencies();
        List<SalesInvoiceDto> ListSalesInvoices(DateTime StartDate, DateTime EndDate, string Search);
        List<SalesDetailsDto> ListSalesDetails(int InvoiceId);

    }
}
