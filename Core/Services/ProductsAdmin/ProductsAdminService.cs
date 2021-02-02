using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Entities.ProductsAdmin;
using HardwareStore.Core.Interfaces.Catalogs;
using HardwareStore.Core.Interfaces.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Services.ProductsAdmin
{
    public class ProductsAdminService : IProductsAdminService
    {
        private readonly IProductsStocksRepository _StocksRepository;
        private readonly IWarehouseRepository _WarehouseRepository;
        private readonly IMeasureUnitsRepository _MeasureUnitsRepository;
        private readonly IRemovedProductsRepository _RemovedProductsRepository;
        public ProductsAdminService(IProductsStocksRepository _StocksRepository, IWarehouseRepository _WarehouseRepository, IMeasureUnitsRepository _MeasureUnitsRepository,
                                    IRemovedProductsRepository _RemovedProductsRepository)
        {
            this._StocksRepository = _StocksRepository;
            this._WarehouseRepository = _WarehouseRepository;
            this._MeasureUnitsRepository = _MeasureUnitsRepository;
            this._RemovedProductsRepository = _RemovedProductsRepository;
        }

        public Response DeleteProductFromStocks(DeleteProductDto dto)
        {
            try
            {
                RemovedProducts Rmprod = this.MapRemovedProductsData(dto);
                List<StocksUpdateDto> stocks = this.MapStocksDetails(dto);
                this._RemovedProductsRepository.RegisterRemovedProducts(Rmprod);
                this._StocksRepository.UpdateStocksDetails(stocks);
                return new Response() { Title = "¡Operación exitosa!", Message = string.Format("Se han eliminado {0} Unidades de las existencias del producto", dto.UnitQuantity), Success = true };
            }
            catch (Exception exc)
            {

                return new Response() { Title = "¡Error al eliminar de las existencias!", Message = exc.Message, Success = false };
            }
        }

        private RemovedProducts MapRemovedProductsData(DeleteProductDto dto)
        {
            try
            {
                RemovedProducts Rmprod = new RemovedProducts()
                {
                    ProductStocksId = dto.ProductStockId,
                    LotNumber = dto.LotNumber,
                    StocksDetailCode = dto.StockDetailCode,
                    MeasureUnitId = dto.MeasureUnitId,
                    UnitQuantity = dto.UnitQuantity,
                    UnitBaseId = dto.UnitBaseId,
                    ConversionQuantity = dto.ConversionQuantity,
                    Title = dto.Title,
                    Description = dto.Description,
                    CreatedAt = DateTime.Now,
                    CreatedBy = dto.User
                };

                return Rmprod;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private List<StocksUpdateDto> MapStocksDetails(DeleteProductDto Delprod)
        {
            try
            {
                double stock;
                stock = 0;
                StocksUpdateDto data = new StocksUpdateDto();
                StocksDetailsDto dto = new StocksDetailsDto();
                List<StocksUpdateDto> details = new List<StocksUpdateDto>();
                dto = this.GetAStocksDetail(Delprod.StockDetailCode);
                data.UnitBaseQuantity = (double)dto.ConversionValue - Delprod.ConversionQuantity;
                stock = this.GetConversionValue(dto.UnitBaseId, dto.PurchaseUnitId, data.UnitBaseQuantity);
                data.UnitPurchasedQuantity = stock;
                data.LotNumber = dto.LotNumber;
                data.StockCode = dto.StocksCode;
                details.Add(data);

                return details;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private double GetConversionValue(int IdConvertFrom, int IdConvertTo, double? Value = null)
        {
            try
            {
                double ConversionValue = 0;

                if (Value != null)
                {
                    double BaseValue = this._MeasureUnitsRepository.GetConversionValueById(IdConvertFrom, IdConvertTo).Value;
                    ConversionValue = (double)Value * BaseValue;
                }
                else
                {
                    ConversionValue = this._MeasureUnitsRepository.GetConversionValueById(IdConvertFrom, IdConvertTo).Value;
                }

                return ConversionValue;
            }
            catch (Exception exc)
            {

                throw exc;
            }
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

        public List<RemovedProductsDto> GetRemovedProducts(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                List<RemovedProductsDto> list = new List<RemovedProductsDto>();
                list = this._RemovedProductsRepository.GetRemovedProducts(StartDate, EndDate, Search);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
