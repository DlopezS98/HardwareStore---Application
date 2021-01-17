using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class PurchaseTransacDto
    {
        public int SupplierId { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public int TotalProducts { get; set; }
        public double Tax { get; set; }
        public double Subtotal { get; set; }
        public int Discount { get; set; }
        public string UserName { get; set; }
        public double TotalAmount { get; set; }
        public List<TempPurchaseList> Details { get; set; }
    }
}
