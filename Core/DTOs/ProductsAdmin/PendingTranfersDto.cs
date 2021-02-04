using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareStore.Core.Entities.Enums;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class PendingTranfersDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ProductStocksId { get; set; }
        public string SupplierName { get; set; }
        public string LotNumber { get; set; }
        public string StocksCode { get; set; }
        public string ProductDetailCode { get; set; }
        public string ProductName { get; set; }
        public int WarehouseId { get; set; }
        public string SourceWarehouse { get; set; }
        public int TargetWarehouseId { get; set; }
        public string TargetWarehouse { get; set; }
        public int UnitBaseId { get; set; }
        public string UnitBaseName { get; set; }
        public int TargetUnitId { get; set; }
        public string TargetUnitName { get; set; }
        public int UnitQuantity { get; set; }
        public int UnitConversionId { get; set; }
        public int PurchasedUnitId { get; set; }
        public double ConversionQuantity { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int TransferStatus { get; set; }
    }
}
