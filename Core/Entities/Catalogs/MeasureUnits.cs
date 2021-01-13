using HardwareStore.Core.Entities.Billing;
using HardwareStore.Core.Entities.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Catalogs
{
    public class MeasureUnits : BaseEntity
    {
        public int UnitTypeId { get; set; }
        public string Name { get; set; }
        public string Abbrevation { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool BaseUnit { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<DetailProductStocks> DetailProductStocks { get; set; }
        public virtual UnitTypes UnitTypes { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
