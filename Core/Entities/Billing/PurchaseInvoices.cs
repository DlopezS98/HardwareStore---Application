using HardwareStore.Core.Entities.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Billing
{
    public class PurchaseInvoices : BaseEntity
    {
        public int SupplierId { get; set; }
        public string InvoiceNumber { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public double Tax { get; set; }
        public double Subtotal { get; set; }
        public int Discount { get; set; }
        public double TotalAmount { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}
