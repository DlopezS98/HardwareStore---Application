using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Billing
{
    public interface IPurchaseRepository
    {
        List<InvoicesDto> GetPurhaseInvoices(DateTime StartDate, DateTime EndDate, string Search);
        DataTable GetPurchaseInvoicesFromDataBase(DateTime StartDate, DateTime EndDate, string Search);
        DataTable GetPurchaseInvoiceDetailsFromDataBase(int InvoiceId);
        List<InvoiceDetailsDto> GetPurchaseInvoiceDetails(int InvoiceId);
        void CreateNewPurchase(PurchaseInvoices Invoice);
        void CreatePurchaseDetails(List<PurchaseDetails> Details);
    }
}
