using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Catalogs
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }
        public int UnitTypeId { get; set; }
        public int MeasureUnitId { get; set; }
        public string ProductName { get; set; }
        public string MeasureUnitAndAbbreviation { get => this.MeasureUnit + " ("+ this.Abbreviation + ")"; }
        public string MeasureUnit { get; set; }
        public string Abbreviation { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public string Code { get; set; }
        public string DefaultCode { get; set; }
        public string Dimensions { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Status { get; set; }
    }
}
