using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class DeleteProductDto
    {
        public int ProductStockId { get; set; }
        public string LotNumber { get; set; }
        public string StockDetailCode { get; set; }
        public int MeasureUnitId { get; set; }
        public int UnitQuantity { get; set; }
        public int UnitBaseId { get; set; }
        public int PurchasedUnitId { get; set; }
        public double ConversionQuantity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string User { get; set; }
    }
}
