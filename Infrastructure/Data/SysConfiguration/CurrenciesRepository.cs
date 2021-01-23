using HardwareStore.Core.DTOs.SysConfiguration;
using HardwareStore.Core.Entities.SysConfiguration;
using HardwareStore.Core.Interfaces.SysConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.SysConfiguration
{
    public class CurrenciesRepository : EntityRepository, ICurrenciesRepository
    {
        private readonly AplicationContext _dbContext;
        public CurrenciesRepository(AplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public CurrencyExchangeDto GetACurrencyExchange(int local, int foreign)
        {
            try
            {
                CurrencyExchangeDto dto = new CurrencyExchangeDto();
                CurrencyExchange Currency = new CurrencyExchange();
                Currency = this._dbContext.CurrencyExchange.FirstOrDefault(x => x.LocalId == local && x.ForeignId == foreign && x.Deleted == false);
                dto.Id = Currency.Id; dto.LocalId = Currency.LocalId; dto.ForeignId = Currency.ForeignId; dto.Sale = Currency.Sale; dto.Purchase = Currency.Purchase;
                dto.CreatedAt = Currency.CreatedAt; dto.CreatedBy = Currency.CreatedBy; dto.UpdatedAt = Currency.UpdatedAt; dto.UpdatedBy = Currency.UpdatedBy;

                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<ForeignCurrencyDropDto> ListForeignCurrencies()
        {
            try
            {
                List<ForeignCurrencies> list = new List<ForeignCurrencies>();
                List<ForeignCurrencyDropDto> ForeignCurrency = new List<ForeignCurrencyDropDto>();
                list = this._dbContext.ForeignCurrencies.Where(x => x.Deleted == false).ToList();
                list.ForEach(x => ForeignCurrency.Add(new ForeignCurrencyDropDto() {
                    Id = x.Id,
                    Name = x.Name
                })) ;

                return ForeignCurrency;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<LocalCurrencyDropDto> ListLocalCurrencies()
        {
            try
            {
                List<LocalCurrencies> list = new List<LocalCurrencies>();
                List<LocalCurrencyDropDto> LocalCurrency = new List<LocalCurrencyDropDto>();
                list = this._dbContext.LocalCurrencies.Where(x => x.Deleted == false).ToList();
                list.ForEach(x => LocalCurrency.Add(new LocalCurrencyDropDto()
                {
                    Id = x.Id,
                    Name = x.Name
                }));

                return LocalCurrency;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
