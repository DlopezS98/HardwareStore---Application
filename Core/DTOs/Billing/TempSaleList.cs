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
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string ProductDetailCode { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public string Dimensions { get; set; }
        public string ExpirationDate { get; set; }
        public int SaleUnitId { get; set; } //dropdowlistmeasureunits
        public string SaleUnitName { get; set; }
        public int PurchasedUnitId { get; set; }
        public string PurchaseUnitName { get; set; }
        public double ConversionValue { get; set; }
        public int Quantity { get; set; }
        public double SalePrice { get; set; }
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public int Discount { get; set; }
        public double Total { get; set; }
    }
}
