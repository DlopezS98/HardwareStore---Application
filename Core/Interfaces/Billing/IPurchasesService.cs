using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Entities.Catalogs;
using HardwareStore.Core.Entities.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Billing
{
    public interface IPurchasesService
    {
        List<MeasureUnitsDropDto> ListMeasureUnitForDropdownsByType(int TypeId);
        List<ProductDetailsDto> GetProductDetails(Boolean Deleted, string Search);
        List<WarehousesDropDto> GetWarehousesForDropdowns();
        List<SuppliersDropDto> GetSuppliersForDropDowns();
        Response CreateSupplier(SuppliersDto suppliers);
        List<InvoicesDto> GetPurhaseInvoices(DateTime StartDate, DateTime EndDate, string Search);
        List<InvoiceDetailsDto> GetPurchaseInvoiceDetails(int InvoiceId);
        ProductDetailsDto GetAProductDetail(string Code);
        Response RegisterPurchaseTransaction(PurchaseTransacDto Invoice);
        Response CreateWarehouse(WarehousesDto warehouses);
    }
}
