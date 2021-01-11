//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HardwareStore.Infrastructure.Identity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
        public string Code { get; set; }
        public string DefaultCode { get; set; }
        public string Dimensions { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Brands Brands { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual MaterialsTypes MaterialsTypes { get; set; }
        public virtual Products Products { get; set; }
    }
}
