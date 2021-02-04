using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class PendingTranfersModelDto
    {
        public string Code { get; set; }
        public int ProductStocksId { get; set; }
        public string LotNumber { get; set; }
        public string StocksCode { get; set; }
        public string ProductDetailCode { get; set; }
        public int WarehouseId { get; set; }
        public int TargetWarehouseId { get; set; }
        public int UnitTypeId { get; set; }
        public int TargetUnitId { get; set; }
        public int PurchasedUnitId { get; set; }
        public int UnitQuantity { get; set; }
        public string UserName { get; set; }

    }
}
