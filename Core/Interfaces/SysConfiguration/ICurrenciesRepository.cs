using HardwareStore.Core.DTOs.SysConfiguration;
using HardwareStore.Core.Entities.SysConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.SysConfiguration
{
    public interface ICurrenciesRepository
    {
        List<ForeignCurrencyDropDto> ListForeignCurrencies();
        List<LocalCurrencyDropDto> ListLocalCurrencies();
        CurrencyExchangeDto GetACurrencyExchange(int local, int foreign);
    }
}
