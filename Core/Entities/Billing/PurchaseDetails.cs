using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareStore.Core.Entities.Catalogs;

namespace HardwareStore.Core.Entities.Billing
{
    public class PurchaseDetails : BaseEntity
    {
        public int PurchaseInvoiceId { get; set; }
        public string ProductDetailCode { get; set; }
        public int WarehouseId { get; set; }
        public int TargetUnitId { get; set; }
        public int Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public int Discount { get; set; }
        public double Total { get; set; }

        public virtual MeasureUnits MeasureUnits { get; set; }
        public virtual Warehouses Warehouses { get; set; }
        public virtual PurchaseInvoices PurchaseInvoices { get; set; }
    }
}
