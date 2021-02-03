using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Interfaces.Billing;
using HardwareStore.Core.Interfaces.Catalogs;
using HardwareStore.Core.Interfaces.ProductsAdmin;
using HardwareStore.Core.Interfaces.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Services.Reports
{
    public class ReportsService : IReportsService
    {
        private readonly IProductsRepository _ProductsRepository;
        private readonly ISalesRepository _SalesRepository;
        private readonly IPurchaseRepository _PurchaseRepository;
        private readonly IProductsStocksRepository _StocksRepository;
        private readonly IRemovedProductsRepository _RemovedProductsRepository;
        private readonly IWarehouseRepository _WarehouseRepository;
        public ReportsService(IProductsRepository _ProductsRepository, ISalesRepository _SalesRepository, IPurchaseRepository _PurchaseRepository,
                              IProductsStocksRepository _StocksRepository, IRemovedProductsRepository _RemovedProductsRepository, IWarehouseRepository _WarehouseRepository)
        {
            this._ProductsRepository = _ProductsRepository;
            this._SalesRepository = _SalesRepository;
            this._PurchaseRepository = _PurchaseRepository;
            this._StocksRepository = _StocksRepository;
            this._RemovedProductsRepository = _RemovedProductsRepository;
            this._WarehouseRepository = _WarehouseRepository;
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

        public List<ProductStocksDto> GetProductStocks(string Search, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                List<ProductStocksDto> list = new List<ProductStocksDto>();
                list = this._StocksRepository.GetProductStocks(Search, true, StartDate, EndDate);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<StocksDetailsDto> GetProductStocksDetails(string LotNumber, string Search, int WarehouseId)
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

        public List<InvoiceDetailsDto> GetPurchaseInvoiceDetails(int InvoiceId)
        {
            try
            {
                List<InvoiceDetailsDto> list = new List<InvoiceDetailsDto>();
                list = this._PurchaseRepository.GetPurchaseInvoiceDetails(InvoiceId);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<InvoicesDto> GetPurhaseInvoices(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                List<InvoicesDto> list = new List<InvoicesDto>();
                list = this._PurchaseRepository.GetPurhaseInvoices(StartDate, EndDate, Search);
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

        public DataTable GetProductDetailsFromDatabase(bool Deleted, string Search)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this._ProductsRepository.GetProductDetailsFromDatabase(Deleted, Search);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<SalesDetailsDto> ListSalesDetails(int InvoiceId)
        {
            try
            {
                List<SalesDetailsDto> list = new List<SalesDetailsDto>();
                list = this._SalesRepository.ListSalesDetails(InvoiceId);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<SalesInvoiceDto> ListSalesInvoices(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                List<SalesInvoiceDto> list = new List<SalesInvoiceDto>();
                list = this._SalesRepository.ListSalesInvoices(StartDate, EndDate, Search);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
