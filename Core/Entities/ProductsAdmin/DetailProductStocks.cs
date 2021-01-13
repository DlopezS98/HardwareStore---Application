using HardwareStore.Core.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.ProductsAdmin
{
    public class DetailProductStocks : BaseEntity
    {
        public string Code { get; set; }
        public int ProductStocksId { get; set; }
        public int WarehouseId { get; set; }
        public string ProductDetailCode { get; set; }
        public int TargetUnitId { get; set; }
        public int UnitConversionId { get; set; }
        public int UnitsPurchased { get; set; }
        public double ConversionQuantity { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public bool Available { get; set; }

        public virtual MeasureUnits MeasureUnits { get; set; }
        public virtual UnitConversion UnitConversion { get; set; }
        public virtual ProductStocks ProductStocks { get; set; }
        public virtual Warehouses Warehouses { get; set; }
    }
}
