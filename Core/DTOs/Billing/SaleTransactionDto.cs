using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.Billing
{
    public class SaleTransactionDto
    {
        public string User { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CurrencyExchangeId { get; set; }
        public double Tax { get; set; }
        public double Subtotal { get; set; }
        public int Discount { get; set; }
        public double TotalAmount { get; set; }
        public List<TempSaleList> Details { get; set; }
    }
}
