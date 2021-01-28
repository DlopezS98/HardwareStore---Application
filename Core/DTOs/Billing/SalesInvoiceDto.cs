using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class SalesInvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerInvoice { get; set; }
        public string ForeignCurrency { get; set; }
        public double Tax { get; set; }
        public double Subtotal { get; set; }
        public int Discount { get; set; }
        public double TotalAmount { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
