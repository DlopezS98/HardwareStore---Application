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

        public DataTable GetProductStocks(string Search, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this._StocksRepository.GetDataTableProductStocks(Search, true, StartDate, EndDate);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetProductStocksDetails(string LotNumber, string Search, int WarehouseId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this._StocksRepository.GetDataTableProductStocksDetails(LotNumber, Search, WarehouseId);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetPurchaseInvoiceDetails(int InvoiceId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this._PurchaseRepository.GetPurchaseInvoiceDetailsFromDataBase(InvoiceId);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetPurhaseInvoices(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this._PurchaseRepository.GetPurchaseInvoicesFromDataBase(StartDate, EndDate, Search);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetRemovedProducts(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this._RemovedProductsRepository.GetDataTableRemovedProducts(StartDate, EndDate, Search);
                return dt;
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

        public DataTable ListSalesDetails(int InvoiceId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this._SalesRepository.GetDataTableSalesDetails(InvoiceId);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable ListSalesInvoices(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = this._SalesRepository.GetDataTableSalesInvoices(StartDate, EndDate, Search);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
