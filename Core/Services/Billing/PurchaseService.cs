using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Interfaces.Catalogs;
using HardwareStore.Core.Interfaces.Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Services.Billing
{
    public class PurchaseService : IPurchasesService
    {
        private readonly IProductsRepository _ProductsRepository;
        private readonly IWarehouseRepository _WarehouseRepository;
        private readonly ISuppliersRepository _SuppliersRepository;
        private readonly IMeasureUnitsRepository _MeasureUnitsRepository;

        public PurchaseService(IProductsRepository _ProductsRepository, IWarehouseRepository _WarehouseRepository, 
            ISuppliersRepository _SuppliersRepository, IMeasureUnitsRepository _MeasureUnitsRepository)
        {
            this._ProductsRepository = _ProductsRepository;
            this._WarehouseRepository = _WarehouseRepository;
            this._SuppliersRepository = _SuppliersRepository;
            this._MeasureUnitsRepository = _MeasureUnitsRepository;
        }

        public ProductDetailsDto GetAProductDetail(string Code)
        {
            try
            {
                ProductDetailsDto dto = new ProductDetailsDto();
                dto = this._ProductsRepository.GetAProductDetail(Code);
                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<ProductDetailsDto> GetProductDetails(bool Deleted, string Search)
        {
            try
            {
                List<ProductDetailsDto> list = new List<ProductDetailsDto>();
                list = this._ProductsRepository.ListAllProductDetails(Deleted, Search);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<SuppliersDropDto> GetSuppliersForDropDowns()
        {
            try
            {
                List<SuppliersDropDto> list = new List<SuppliersDropDto>();
                list = this._SuppliersRepository.ListSuppliersForDropDowns();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<WarehousesDropDto> GetWarehousesForDropdowns()
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

        public List<MeasureUnitsDropDto> ListMeasureUnitForDropdownsByType(int TypeId)
        {
            try
            {
                List<MeasureUnitsDropDto> list = new List<MeasureUnitsDropDto>();
                list = this._MeasureUnitsRepository.ListMeasureUnitForDropdownsByType(TypeId);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public double GetConversionValueById(int From, int To)
        {
            try
            {
                return this._MeasureUnitsRepository.GetConversionValueById(From, To);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
