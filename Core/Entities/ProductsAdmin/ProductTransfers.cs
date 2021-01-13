using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareStore.Core.Entities.Catalogs;

namespace HardwareStore.Core.Entities.ProductsAdmin
{
    public class ProductTransfers : BaseEntity
    {
        public int ProductStocksId { get; set; }
        public int TargetWarehouseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool TransferStatus { get; set; }

        public virtual ProductStocks ProductStocks { get; set; }
        public virtual Warehouses Warehouses { get; set; }
        public virtual ICollection<TransfersDetails> TransfersDetails { get; set; }
    }
}
