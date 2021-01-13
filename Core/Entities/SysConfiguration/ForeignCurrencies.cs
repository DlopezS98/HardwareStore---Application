using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Entities.SysConfiguration
{
    public class ForeignCurrencies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<CurrencyExchange> CurrencyExchange { get; set; }
    }
}
