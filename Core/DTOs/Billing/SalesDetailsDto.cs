using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class SalesDetailsDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string StockLotNumber { get; set; }
        public string ProductDetailCode { get; set; }
        public string WarehouseName { get; set; }
        public string SaleUnitName { get; set; }
        public string PurchasedUnitName { get; set; }
        public double ConversionValue { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string DisplayPrice { get => "C$" + this.Price.ToString("F2"); }
        public double Subtotal { get; set; }
        public string DisplaySubtotal { get => "C$" + this.Subtotal.ToString("F2"); }
        public double Tax { get; set; }
        public string DisplayTax { get => "C$" + this.Tax.ToString("F2"); }
        public int Discount { get; set; }
        public string DisplayDiscount { get => this.Discount + "%"; }
        public double Total { get; set; }
        public string DisplayTotal { get => "C$" + this.Total.ToString("F2"); }
    }
}
