using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.ProductsAdmin
{
    public class PendingTransfers : BaseEntity
    {
        public string Code { get; set; }
        public int ProductStocksId { get; set; }
        public int TargetWarehouseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool TransferStatus { get; set; }
        public string ProductDetailCode { get; set; }
        public int SourceWarehouseId { get; set; }
        public int TargetUnitId { get; set; }
        public int UnitConversionId { get; set; }
        public int UnitsPurchased { get; set; }
        public double ConversionQuantity { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
    }
}
