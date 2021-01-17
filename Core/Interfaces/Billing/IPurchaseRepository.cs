using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.Entities.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Billing
{
    public interface IPurchaseRepository
    {
        List<PurchasesDto> GetPurhaseInvoices(DateTime StartDate, DateTime EndDate, string InvoiceNumber);
        void CreateNewPurchase(PurchaseInvoices Invoice);
        void CreatePurchaseDetails(List<PurchaseDetails> Details);
    }
}
