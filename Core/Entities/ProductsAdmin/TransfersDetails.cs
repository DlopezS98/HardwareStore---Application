using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardwareStore.Core.Entities.ProductsAdmin
{
    public class TransfersDetails : BaseEntity
    {
        public int ProductTransferId { get; set; }
        public int ProductStocksId { get; set; }
        public string ProductDetailCode { get; set; }
        public int SourceWarehouseId { get; set; }
        public int TargetUnitId { get; set; }
        public int UnitConversionId { get; set; }
        public int UnitsPurchased { get; set; }
        public double ConversionQuantity { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public virtual ProductTransfers ProductTransfers { get; set; }
    }
}