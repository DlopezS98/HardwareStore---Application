using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Entities;
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
        private readonly IPendingTransfersRepository _PendingTransfersRepository;
        private readonly ITransfersRepository _TransfersRepository;

        public ProductsAdminService(IProductsStocksRepository _StocksRepository, IWarehouseRepository _WarehouseRepository, IMeasureUnitsRepository _MeasureUnitsRepository,
                                    IRemovedProductsRepository _RemovedProductsRepository, IPendingTransfersRepository _PendingTransfersRepository, ITransfersRepository _TranfersRepository)
        {
            this._StocksRepository = _StocksRepository;
            this._WarehouseRepository = _WarehouseRepository;
            this._MeasureUnitsRepository = _MeasureUnitsRepository;
            this._RemovedProductsRepository = _RemovedProductsRepository;
            this._PendingTransfersRepository = _PendingTransfersRepository;
            this._TransfersRepository = _TranfersRepository;
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

        public Response CreatePendingTransfer(PendingTranfersModelDto dto)
        {
            try
            {
                List<PendingTranfersDto> list = new List<PendingTranfersDto>();
                list = this.GetPendingTransferProducts("", Enums.TransferStatus.Pending);
                var alreadyexits = list.Exists(x => x.TargetWarehouseId == dto.TargetWarehouseId && x.ProductDetailCode == dto.ProductDetailCode);
                if (alreadyexits)
                {
                    return new Response() { Title = "¡Error al transferir el producto!", Message = "El producto ya existe en la cola", Success = false };
                }
                else
                {
                    this._PendingTransfersRepository.CreatePendingTransfer(dto);
                    return new Response() { Title = "¡Operación exitosa!", Message = "Se ha transferido a la lista de espera", Success = true };
                }

            }
            catch (Exception exc)
            {

                return new Response() { Title = "¡Error al transferir el producto a la lista de espera!", Message = exc.Message, Success = false };
            }
        }

        public Response UpdatePendingTranfer(string Code, PendingTranfersModelDto dto)
        {
            try
            {
                //PendingTranfersDto pending = new PendingTranfersDto();
                List<PendingTranfersDto> list = new List<PendingTranfersDto>();
                list = this.GetPendingTransferProducts("", Enums.TransferStatus.Pending).Where(x => x.Code != Code).ToList();
                //pending = this.GetPendingTransferProduct(Code);
                var alreadyexits = list.Exists(x => x.TargetWarehouseId == dto.TargetWarehouseId && x.ProductDetailCode == dto.ProductDetailCode);
                if (alreadyexits)
                {
                    return new Response() { Title = "¡Error al transferir el producto!", Message = "El producto ya existe en la cola", Success = false };

                }
                else
                {
                    this._PendingTransfersRepository.UpdatePendingTranfer(Code, dto);
                    return new Response() { Title = "¡Operación exitosa!", Message = "Se ha actualizado el producto", Success = true };
                }
            }
            catch (Exception exc)
            {

                return new Response() { Title = "¡Error al actualizar el producto!", Message = exc.Message, Success = false };
            }
        }

        public Response DeleteProductFromTransferList(string Code, string User)
        {
            try
            {
                this._PendingTransfersRepository.UpdateProductStatusInTransferList(Code, User, Enums.TransferStatus.Canceled);
                return new Response() { Title = "¡Operación exitosa!", Message = "Se ha eliminado el producto sastisfactoriamente", Success = true };
            }
            catch (Exception exc)
            {

                return new Response() { Title = "¡Error al eliminar el producto!", Message = exc.Message, Success = false };
            }
        }

        public List<PendingTranfersDto> GetPendingTransferProducts(string Search, Enums.TransferStatus Status)
        {
            try
            {
                List<PendingTranfersDto> list = new List<PendingTranfersDto>();
                list = this._PendingTransfersRepository.GetPendingTransferProducts(Search, Status);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public PendingTranfersDto GetPendingTransferProduct(string Code)
        {
            try
            {
                PendingTranfersDto dto = new PendingTranfersDto();
                dto = this._PendingTransfersRepository.GetPendingTransferProduct(Code);
                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void CreateTranfer(List<PendingTranfersDto> list, string User)
        {
            try
            {
                ProductTransferDto dto = new ProductTransferDto();
                dto.TotalProducts = list.Count;
                dto.CreatedBy = User;
                dto.UpdatedBy = User;
                dto.TranferStatus = Enums.TransferStatus.Done;

                this._TransfersRepository.CreateTranfer(dto);
                
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }


        public List<TransferDetailsDto> ListTransfersDetails(int TransferId, string Search)
        {
            try
            {
                List<TransferDetailsDto> list = new List<TransferDetailsDto>();
                list = this._TransfersRepository.ListTransfersDetails(TransferId, Search);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<TransfersDto> ListProductTransfer(string Search, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                List<TransfersDto> list = new List<TransfersDto>();
                list = this._TransfersRepository.ListProductTransfer(Search, StartDate, EndDate);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public Response GenerateTransferTransaction(List<PendingTranfersDto> list, string User)
        {
            try
            {
                this.VerifyIfThereAreStocksInTheWarehouse(list);
                this.CreateTranfer(list, User);
                this._TransfersRepository.CreateTranfersDetails(list);
                this.UpdateTransferStatusToDone(list, User);
                return new Response() { Title = "¡Operación exitosa!", Message = "Se han transferido los productos", Success = true };
            }
            catch (Exception exc)
            {

                return new Response() { Title = "¡Error!", Message = exc.Message, Success = false };
            }
        }

        private void UpdateTransferStatusToDone(List<PendingTranfersDto> list, string user)
        {
            try
            {
                foreach (PendingTranfersDto item in list)
                {
                    this._PendingTransfersRepository.UpdateProductStatusInTransferList(item.Code, user, Enums.TransferStatus.Done);
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private void VerifyIfThereAreStocksInTheWarehouse(List<PendingTranfersDto> dto)
        {
            try
            {
                List<PendingTranfersDto> list = new List<PendingTranfersDto>();
                foreach (PendingTranfersDto item in dto)
                {
                    StocksDetailsDto stocks = this.GetAStocksDetail(item.StocksCode);
                    var data = this.GetPendingTransferProducts("", Enums.TransferStatus.Pending).Where(x => x.ProductDetailCode == item.ProductDetailCode).ToList();
                    int quantity = data.Sum(x => x.UnitQuantity);
                    double value = this.GetConversionValue(item.TargetUnitId, stocks.UnitBaseId, quantity);
                    if (value > stocks.ConversionValue)
                    {
                        throw new Exception($"El total a transferir ({quantity}) del producto con código {item.ProductDetailCode} excede las existencias en la bodega: {item.SourceWarehouse} - existencias: {stocks.StocksQuantity}");
                    }
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private List<StocksUpdateDto> MapStocksDetailsDecrement(List<PendingTranfersDto> list)
        {
            try
            {
                double stock;
                List<StocksUpdateDto> details = new List<StocksUpdateDto>();
                foreach (PendingTranfersDto item in list)
                {
                    stock = 0;
                    StocksUpdateDto data = new StocksUpdateDto();
                    StocksDetailsDto dto = new StocksDetailsDto();
                    dto = this.GetAStocksDetail(item.StocksCode);
                    data.UnitBaseQuantity = (double)dto.ConversionValue - item.ConversionQuantity;
                    stock = this.GetConversionValue(dto.UnitBaseId, dto.PurchaseUnitId, data.UnitBaseQuantity);
                    data.UnitPurchasedQuantity = stock;
                    data.LotNumber = dto.LotNumber;
                    data.StockCode = dto.StocksCode;
                    data.StockCode = dto.StocksCode;
                    details.Add(data);
                }

                return details;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
