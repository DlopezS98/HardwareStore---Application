using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class SalesInvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public string ForeignCurrency { get; set; }
        public string ForeignSymbol { get; set; }
        public string LocalCurrency { get; set; }
        public string LocalSymbol { get; set; }
        public double CurrencySale { get; set; }
        public string DisplayCurrencySale { get => this.LocalSymbol + "" + this.CurrencySale; }
        public double CurrencyPurchase { get; set; }
        public string DisplayCurrencyPurchase { get => this.LocalSymbol + "" + this.CurrencyPurchase; }
        public double Payment { get; set; }
        public string DisplayPayment { get => this.ForeignSymbol + "" + this.Payment; }
        public double PaymentChange { get; set; }
        public string DisplayPaymentChange { get => this.LocalSymbol + "" + this.PaymentChange; }
        public double Tax { get; set; }
        public string DisplayTax { get => this.LocalSymbol + "" + this.Tax; }
        public double Subtotal { get; set; }
        public string DisplaySubtotal { get => this.LocalSymbol + "" + this.Subtotal.ToString("F2"); }
        public int Discount { get; set; }
        public string DisplayDiscount { get => this.Discount +"%"; }
        public double TotalAmount { get; set; }
        public string DisplayTotalAmount { get => this.LocalSymbol + "" + this.TotalAmount.ToString("F2"); }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
