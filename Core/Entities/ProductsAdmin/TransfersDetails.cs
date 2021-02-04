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
        public string LotNumber { get; set; }
        public string ProductDetailCode { get; set; }
        public string StocksCode { get; set; }
        public int TargetWarehouseId { get; set; }
        public int UnitBaseId { get; set; }
        public int TargetUnitId { get; set; }
        public int UnitConversionId { get; set; }
        public int UnitQuantity { get; set; }
        public double ConversionQuantity { get; set; }
        public virtual ProductTransfers ProductTransfers { get; set; }
    }
}