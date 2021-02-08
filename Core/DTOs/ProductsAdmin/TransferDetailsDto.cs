using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class TransferDetailsDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ProductTransferId { get; set; }
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
        public double ConversionQuantity { get; set; }
    }
}
