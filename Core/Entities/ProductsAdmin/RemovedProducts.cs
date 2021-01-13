using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.ProductsAdmin
{
    public class RemovedProducts
    {
        public int Id { get; set; }
        public int ProductStocksId { get; set; }
        public string LotNumber { get; set; }
        public string StocksDetailCode { get; set; }
        public int UnitQuantity { get; set; }
        public double ConversionQuantity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual ProductStocks ProductStocks { get; set; }
    }
}
