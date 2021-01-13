using HardwareStore.Core.Entities.Catalogs;
using HardwareStore.Core.Entities.SysConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Billing
{
    public class SalesInvoices
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string CustomerInvoice { get; set; }
        public int CurrencyExchangeId { get; set; }
        public double Tax { get; set; }
        public double Subtotal { get; set; }
        public int Discount { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        public virtual CurrencyExchange CurrencyExchange { get; set; }
        public virtual Customers Customers { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
