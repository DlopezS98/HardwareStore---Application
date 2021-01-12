using HardwareStore.Core.DTOs.Products;
using HardwareStore.Core.DTOs.Warehouses;
using HardwareStore.Core.Interfaces;
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

        public PurchaseService(IProductsRepository vProductsRepository, IWarehouseRepository WarehouseRepository)
        {
            this._ProductsRepository = vProductsRepository;
            this._WarehouseRepository = WarehouseRepository;
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
    }
}
