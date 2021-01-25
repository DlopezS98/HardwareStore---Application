using HardwareStore.Core.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Billing
{
    public class SalesDetails : BaseEntity
    {
        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleInvoiceId { get; set; }
        public string StockLotNumber { get; set; }
        //[Key]
        //[Column(Order = 1)]
        //[StringLength(255)]
        public string ProductDetailCode { get; set; }
        public double ConversionValue { get; set; }
        //[Key]
        //[Column(Order = 2)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WarehouseId { get; set; }

        //[Key]
        //[Column(Order = 3)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TargetUnitId { get; set; }
        public int PurchasedUnitId { get; set; }
        public int UnitConversionId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }

        public virtual MeasureUnits MeasureUnits { get; set; }
        public virtual SalesInvoices SalesInvoices { get; set; }
        public virtual UnitConversions UnitConversions { get; set; }
        public virtual Warehouses Warehouses { get; set; }
    }
}
