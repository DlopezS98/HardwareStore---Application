using HardwareStore.Core.DTOs.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class TempPurchaseList//: ProductDetailsDto
    {
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string MaterialName { get; set; }
        public string MeasureUnitBase { get; set; }
        public string Dimensions { get; set; }
        public string WarehouseName { get; set; }
        public int WarehouseId { get; set; }
        public string UnitPurchased { get; set; }
        public int TargetUnitId { get; set; }
        public double UnitConversion { get; set; }
        public double PurchasePrice { get; set; } //Precio venta se calcula en base a la conversion
        public double SalePrice { get; set; }
        public int Quantity { get; set; }
        public string UnitsPurchasedString { get => this.Quantity + " " + this.UnitPurchased; }
        public string UnitsBaseConversion { get => this.UnitConversion + " "+ this.MeasureUnitBase; }
        public int Discount { get; set; }
        public double Subtotal { get => this.Quantity* this.PurchasePrice; }
        public double Tax { get; set; }
        public double Total { get => (this.Subtotal - (((double)this.Discount / 100) * this.Subtotal)); }
    }
}
