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
        public Nullable<double> ConversionValue { get; set; }
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public string Dimensions { get; set; }
        public double StocksQuantity { get; set; }
        public double PurchasePrice { get; set; }
        public Nullable<double> SalePriceByUnitBase { get; set; }
        public double SalePrice { get; set; }
        public string ExpirationDate { get; set; }
        public string Available { get; set; }
    }
}
