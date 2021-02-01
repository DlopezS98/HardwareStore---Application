using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class StocksDetailsDto
    {
        public string LotNumber { get; set; }
        public string SupplierName { get; set; }
        public string StocksCode { get; set; }
        public int ProductStocksId { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string ProductDetailCode { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int PurchaseUnitId { get; set; }
        public string PurchaseUnitName { get; set; }
        public int UnitBaseId { get; set; }
        public string UnitBaseName { get; set; }
        public int UnitTypeId { get; set; }
        public double ConversionValue { get; set; }
        public string ConversionValueStr { get => this.ConversionValue.ToString("F2"); }
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public string Dimensions { get; set; }
        public int OriginalQuantity { get; set; }
        public double StocksQuantity { get; set; }
        public string StocksQuantityStr { get => this.StocksQuantity.ToString("F2"); }
        public double PurchasePrice { get; set; }
        public double SalePriceByUnitBase { get; set; }
        public string SalePriceByUnitBaseStr { get => this.SalePriceByUnitBase.ToString("F2"); }
        public double SalePrice { get; set; }
        public string SalePriceStr { get => "C$" + this.SalePrice.ToString("F2"); }
        public string ExpirationDate { get; set; }
        public string Available { get; set; }
    }
}
