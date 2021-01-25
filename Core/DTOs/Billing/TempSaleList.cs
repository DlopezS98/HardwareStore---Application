using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class TempSaleList
    {
        public string LotNumber { get; set; }
        public string StocksCode { get; set; }
        public string SupplierName { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string ProductDetailCode { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public string Dimensions { get; set; }
        public string ExpirationDate { get; set; }
        public int UnitTypeId { get; set; }
        public int UnitBaseId { get; set; }
        public double UnitBaseStocks { get; set; }
        public string UnitBaseName { get; set; }
        public int SaleUnitId { get; set; } //dropdowlistmeasureunits
        public string SaleUnitName { get; set; }
        public int PurchasedUnitId { get; set; }
        public double StocksQuantity { get; set; }
        public string PurchaseUnitName { get; set; }
        public double PurchasedPrice { get; set; }
        public double SalePriceByUnitBase { get; set; }
        public double SalePriceByUnitPurchase { get; set; }
        public int Quantity { get; set; }
        public double SalePrice { get; set; }
        public string SalePriceStr { get => "C$" + this.SalePrice; }
        public double Subtotal { get => (this.Quantity * this.SalePrice) + (this.Quantity * this.Tax); }
        public string SubtotalStr { get => "C$" + this.Subtotal; }
        public double Tax { get; set; }
        public string TaxStr { get => "C$" + this.Tax; }
        public int Discount { get; set; }
        public string DiscountStr { get => this.Discount + "%"; }
        public double Total { get => (this.Subtotal - (((double)this.Discount / 100) * this.Subtotal)); }
        public string TotalStr { get => "C$" + this.Total;  }
        public double ConversionToUpdate { get; set; }
    }
}
