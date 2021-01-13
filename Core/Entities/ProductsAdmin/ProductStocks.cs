using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareStore.Core.Entities.Providers;

namespace HardwareStore.Core.Entities.ProductsAdmin
{
    public class ProductStocks
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string LotNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Available { get; set; }
        public virtual ICollection<DetailProductStocks> DetailProductStocks { get; set; }
        public virtual Suppliers Suppliers { get; set; }
        public virtual ICollection<ProductTransfers> ProductTransfers { get; set; }
        public virtual ICollection<RemovedProducts> RemovedProducts { get; set; }
    }
}
