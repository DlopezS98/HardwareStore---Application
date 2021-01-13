using HardwareStore.Core.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Billing
{
    public class SalesDetails
    {
        public int SaleInvoiceId { get; set; }
        public string ProductDetailCode { get; set; }
        public int WarehouseId { get; set; }
        public int TargetUnitId { get; set; }
        public int UnitConversionId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }

        public virtual MeasureUnits MeasureUnits { get; set; }
        public virtual SalesInvoices SalesInvoices { get; set; }
        public virtual UnitConversion UnitConversion { get; set; }
        public virtual Warehouses Warehouses { get; set; }
    }
}
