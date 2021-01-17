using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class InvoiceDetailsDto
    {
        public int Id { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public string ProductDetailCode { get; set; }
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
        public string MeasureUnit { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public int Discount { get; set; }
        public double Total { get; set; }
    }
}
