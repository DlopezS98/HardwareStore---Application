using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class ProductStocksDto
    {
        public string LotNumber { get; set; }
        public string SupplierName { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Available { get; set; }
        public virtual List<StocksDetailsDto> StocksDetails { get; set; }
    }
}
