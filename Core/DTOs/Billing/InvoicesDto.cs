using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class InvoicesDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string SupplierName { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public double Tax { get; set; }
        public double Subtotal { get; set; }
        public int Discount { get; set; }
        public double TotalAmount { get; set; }
        public string CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
