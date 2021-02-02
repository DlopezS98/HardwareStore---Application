using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class RemovedProductsDto
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProductStocksId { get; set; }
        public string ProductDetailCode { get; set; }
        public string LotNumber { get; set; }
        public string StocksDetailCode { get; set; }
        public string MeasureUnitName { get; set; }
        public int MeasureUnitId { get; set; }
        public int UnitQuantity { get; set; }
        public string UnitBaseName { get; set; }
        public int UnitBaseId { get; set; }
        public double ConversionQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DisplayDate { get => this.CreatedAt.ToString("dd-MMM-yyyy"); }
        public string CreatedBy { get; set; }
    }
}
