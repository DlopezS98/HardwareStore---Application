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
    
    public partial class DetailProductStocks
    {
        public string Code { get; set; }
        public int ProductStocksId { get; set; }
        public int WarehouseId { get; set; }
        public string ProductDetailCode { get; set; }
        public int TargetUnitId { get; set; }
        public int UnitConversionId { get; set; }
        public int UnitsPurchased { get; set; }
        public double ConversionQuantity { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public bool Available { get; set; }
    
        public virtual MeasureUnits MeasureUnits { get; set; }
        public virtual UnitConversion UnitConversion { get; set; }
        public virtual ProductStocks ProductStocks { get; set; }
        public virtual Warehouses Warehouses { get; set; }
    }
}
