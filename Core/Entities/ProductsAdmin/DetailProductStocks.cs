using HardwareStore.Core.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.ProductsAdmin
{
    public class DetailProductStocks : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Code { get; set; }
        public int ProductStocksId { get; set; }
        public int WarehouseId { get; set; }
        public string ProductDetailCode { get; set; }
        public int TargetUnitId { get; set; }
        public int UnitConversionId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int OriginalQuantity { get; set; }
        public double Quantity { get; set; }
        public double ConversionQuantity { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public Nullable<double> SalePriceByUnitBase { get; set; }
        public bool Available { get; set; }

        [ForeignKey("TargetUnitId")]
        public virtual MeasureUnits MeasureUnits { get; set; }
        [ForeignKey("UnitConversionId")]
        public virtual UnitConversions UnitConversions { get; set; }
        [ForeignKey("ProductStocksId")]
        public virtual ProductStocks ProductStocks { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouses Warehouses { get; set; }
    }
}
