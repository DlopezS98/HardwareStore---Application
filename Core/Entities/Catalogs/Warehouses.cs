using HardwareStore.Core.Entities.Billing;
using HardwareStore.Core.Entities.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Catalogs
{
    public class Warehouses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<DetailProductStocks> DetailProductStocks { get; set; }
        public virtual ICollection<ProductTransfers> ProductTransfers { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
