using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Billing
{
    public interface ISalesRepository
    {
        void CreateSaleInvoice(SalesInvoices invoice);
        void CreateInvoiceDetails(List<SalesDetails> details);
        List<SalesInvoiceDto> ListSalesInvoices(DateTime StartDate, DateTime EndDate, string Search);
        List<SalesDetailsDto> ListSalesDetails(int InvoiceId);
    }
}
