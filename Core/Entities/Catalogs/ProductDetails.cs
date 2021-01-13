using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.Catalogs
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
        public string Code { get; set; }
        public string DefaultCode { get; set; }
        public string Dimensions { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        public virtual Brands Brands { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual MaterialsTypes MaterialsTypes { get; set; }
        public virtual Products Products { get; set; }
    }
}
