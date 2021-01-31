using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class StocksUpdateDto
    {
        public string LotNumber { get; set; }
        public string StockCode { get; set; }
        public double UnitBaseQuantity { get; set; }
        public double UnitPurchasedQuantity { get; set; }
    }
}
