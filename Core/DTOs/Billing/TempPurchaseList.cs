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
        public int MeasureUnitBaseId { get; set; }
        public int UnitTypeId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ExpiryDate { get { if (this.ExpirationDate > DateTime.Now) { return this.ExpirationDate.ToString("dd-MMM-yyyy"); } else { return "00-000-00000"; } } }
        public string MeasureUnitBase { get; set; }
        public string CategoryName { get; set; }
        public string DefaultCode { get; set; }
        public string Dimensions { get; set; }
        public string WarehouseName { get; set; }
        public int WarehouseId { get; set; }
        public string Abbreviation { get; set; }
        public string UnitPurchased { get; set; }
        public int TargetUnitId { get; set; }
        public string TargetUnitName { get; set; }
        public double PurchasePrice { get; set; } //Precio venta se calcula en base a la conversion
        public double SalePriceByUnitBase { get; set; }
        public string PurchasePriceStr { get => "C$" + this.PurchasePrice; }
        public double SalePrice { get; set; }
        public string SalePriceStr { get => "C$" + this.SalePrice; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public string DiscountStr { get => this.Discount + "%"; }
        public double Subtotal { get => this.Quantity * this.PurchasePrice; }
        public string SubtotalStr { get => "C$" + this.Subtotal; }
        public double Tax { get; set; }
        public string TaxStr { get => "C$" + this.Tax; }
        public double Total { get => (this.Subtotal - (((double)this.Discount / 100) * this.Subtotal)) + (this.Quantity * this.Tax); }
        public string TotalStr { get => "C$" + this.Total; }
    }
}
