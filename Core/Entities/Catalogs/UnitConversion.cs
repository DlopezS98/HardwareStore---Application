using HardwareStore.Core.Entities.Billing;
using HardwareStore.Core.Entities.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Catalogs
{
    public class UnitConversions : BaseEntity
    {
        public int IdMeasureUnitFrom { get; set; }
        public int IdMeasureUnitTo { get; set; }
        public string ConversionNameFrom { get; set; }
        public string ConversionNameTo { get; set; }
        public double ConversionValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<DetailProductStocks> DetailProductStocks { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
