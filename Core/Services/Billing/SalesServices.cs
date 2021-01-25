using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Interfaces.Billing;
using HardwareStore.Core.Interfaces.Catalogs;
using HardwareStore.Core.Interfaces.ProductsAdmin;
using HardwareStore.Core.Interfaces.SysConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Services.Billing
{
    public class SalesServices : ISalesServices
    {
        private readonly IProductsStocksRepository _StocksRepository;
        private readonly IWarehouseRepository _WarehouseRepository;
        private readonly IMeasureUnitsRepository _MeasureUnitsRepository;
        private readonly ICurrenciesRepository _CurrencyRepository;

        public SalesServices(IProductsStocksRepository _StocksRepository, IWarehouseRepository _WarehouseRepository,
                             IMeasureUnitsRepository _MeasureUnitsRepository, ICurrenciesRepository _CurrencyRepository)
        {
            this._StocksRepository = _StocksRepository;
            this._WarehouseRepository = _WarehouseRepository;
            this._MeasureUnitsRepository = _MeasureUnitsRepository;
            this._CurrencyRepository = _CurrencyRepository;
        }

        public StocksDetailsDto GetAStocksDetail(string StocksCode)
        {
            try
            {
                StocksDetailsDto dto = new StocksDetailsDto();
                dto = this._StocksRepository.GetStocksDetail(StocksCode);
                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<MeasureUnitsDropDto> ListMeasureUnitForDropdownsByType(int TypeId)
        {
            try
            {
                List<MeasureUnitsDropDto> List = new List<MeasureUnitsDropDto>();
                List = this._MeasureUnitsRepository.ListMeasureUnitForDropdownsByType(TypeId);
                return List;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<ProductStocksDto> ListProductStocks(string Search, bool Available, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                List<ProductStocksDto> list = new List<ProductStocksDto>();
                list = this._StocksRepository.GetProductStocks(Search, Available, StartDate, EndDate);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<StocksDetailsDto> ListStocksDetails(string LotNumber, string Search, int WarehouseId)
        {
            try
            {
                List<StocksDetailsDto> list = new List<StocksDetailsDto>();
                list = this._StocksRepository.GetProductStocksDetails(LotNumber, Search, WarehouseId);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<WarehousesDropDto> ListWarehousesForDropDowns()
        {
            try
            {
                List<WarehousesDropDto> list = new List<WarehousesDropDto>();
                list = this._WarehouseRepository.GetWarehousesForDropdownsList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public Response RegisterSaleTransaction(SaleTransactionDto Invoice)
        {
            try
            {

                this.UpdateProductStocks(Invoice);
                return new Response() { Title = "¡Operación Exitosa!", Message = "Venta realizada con éxito", Success = true };
            }
            catch (Exception exc)
            {
                return new Response() { Title = "¡Error al realizar la venta!", Message = exc.Message, Success = false };
            }
        }

        public void CreateSaleInvoice(SaleTransactionDto invoice)
        {
            try
            {

            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void UpdateProductStocks(SaleTransactionDto Sales)
        {
            try
            {
                double stock;
                List<StocksUpdateDto> details = new List<StocksUpdateDto>();
                List<TempSaleList> temp = new List<TempSaleList>();
                temp = Sales.Details;
                foreach (TempSaleList item in temp)
                {
                    stock = 0;
                    StocksUpdateDto data = new StocksUpdateDto();
                    StocksDetailsDto dto = new StocksDetailsDto();
                    dto = this.GetAStocksDetail(item.StocksCode);
                    data.UnitBaseQuantity = (double)dto.ConversionValue - item.ConversionToUpdate;
                    stock = this.GetConversionValue(dto.UnitBaseId, dto.PurchaseUnitId, data.UnitBaseQuantity);
                    data.UnitPurchasedQuantity = stock;
                    data.LotNumber = dto.LotNumber;
                    data.StockCode = dto.StocksCode;
                    details.Add(data);
                }

            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public double GetConversionValue(int IdConvertFrom, int IdConvertTo, double? Value = null)
        {
            try
            {
                double ConversionValue = 0;

                if (Value != null)
                {
                    double BaseValue = this._MeasureUnitsRepository.GetConversionValueById(IdConvertFrom, IdConvertTo);
                    ConversionValue = (double)Value * BaseValue;
                }
                else
                {
                    ConversionValue = this._MeasureUnitsRepository.GetConversionValueById(IdConvertFrom, IdConvertTo);
                }

                return ConversionValue;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
