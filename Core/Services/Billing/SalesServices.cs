using HardwareStore.Core.DTOs;
using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.DTOs.SysConfiguration;
using HardwareStore.Core.Entities;
using HardwareStore.Core.Entities.Billing;
using HardwareStore.Core.Entities.Catalogs;
using HardwareStore.Core.Interfaces;
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
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IPersonsRepository _PersonsRepository;
        private readonly ISalesRepository _SalesRepository;

        public SalesServices(IProductsStocksRepository _StocksRepository, IWarehouseRepository _WarehouseRepository,
                             IMeasureUnitsRepository _MeasureUnitsRepository, ICurrenciesRepository _CurrencyRepository,
                             ICustomerRepository _CustomerRepository, IPersonsRepository _PersonsRepository, ISalesRepository _SalesRepository)
        {
            this._StocksRepository = _StocksRepository;
            this._WarehouseRepository = _WarehouseRepository;
            this._MeasureUnitsRepository = _MeasureUnitsRepository;
            this._CurrencyRepository = _CurrencyRepository;
            this._CustomerRepository = _CustomerRepository;
            this._PersonsRepository = _PersonsRepository;
            this._SalesRepository = _SalesRepository;
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
                SalesInvoices invoice = this.MapSaleInvoiceData(Invoice);
                List<SalesDetails> details = this.MapSaleDetailsData(Invoice.Details);
                List<StocksUpdateDto> stocks = this.MapStocksDetails(Invoice);
                this._SalesRepository.CreateSaleInvoice(invoice);
                this._SalesRepository.CreateInvoiceDetails(details);
                this._StocksRepository.UpdateStocksDetails(stocks);
                return new Response() { Title = "¡Operación Exitosa!", Message = "Venta realizada con éxito", Success = true };
            }
            catch (Exception exc)
            {
                return new Response() { Title = "¡Error al realizar la venta!", Message = exc.Message, Success = false };
            }
        }

        private SalesInvoices MapSaleInvoiceData(SaleTransactionDto dto)
        {
            try
            {
                SalesInvoices Invoce = new SalesInvoices()
                {
                    CustomerId = dto.CustomerId,
                    CustomerInvoice = dto.CustomerName,
                    CurrencyExchangeId = dto.CurrencyExchangeId,
                    Payment = dto.Payment,
                    PaymentChange = dto.PaymentChange,
                    Tax = dto.Tax,
                    Subtotal = dto.Subtotal,
                    Discount = dto.Discount,
                    TotalAmount = dto.TotalAmount,
                    CreatedBy = dto.User
                };

                return Invoce;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private List<SalesDetails> MapSaleDetailsData(List<TempSaleList> Details)
        {
            try
            {
                List<SalesDetails> list = new List<SalesDetails>();
                if (Details.Count > 0)
                {
                    Details.ForEach(x => list.Add(new SalesDetails()
                    {
                        StockLotNumber = x.LotNumber,
                        ProductDetailCode = x.ProductDetailCode,
                        WarehouseId = x.WarehouseId,
                        SaleUnitId = x.SaleUnitId,
                        PurchasedUnitId = x.PurchasedUnitId,
                        UnitConversionId = x.UnitConversionId,
                        ConversionValue = x.ConversionToUpdate,
                        Quantity = x.Quantity,
                        Price = x.SalePrice,
                        Subtotal = x.Subtotal,
                        Tax = x.Tax,
                        Discount = x.Discount,
                        Total = x.Total
                    }));
                }

                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private List<StocksUpdateDto> MapStocksDetails(SaleTransactionDto Sales)
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

                return details;
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

        public List<CustomersDropDto> ListCustomersForDropDownList()
        {
            try
            {
                List<CustomersDropDto> list = new List<CustomersDropDto>();
                list = this._CustomerRepository.GetCustomersForDropDownList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public Response CreateCustomer(string User, CustomersDto customer)
        {
            try
            {
                Persons person = this.MapPersonData(customer);
                int Id = this._PersonsRepository.CreateNewPerson(person);
                Customers Customer = this.MapCustomerData(Id, customer.Initials, User);
                this._CustomerRepository.CreateNewCustomer(Customer);

                return new Response() { Title = "¡Operación exitosa!", Message = "¡Cliente registrado correctamente!", Success = true };
            }
            catch (Exception exc)
            {

                return new Response() { Title = "¡Error al registrar el cliente!", Message = exc.Message, Success = true };
            }
        }

        private Customers MapCustomerData(int PersonId, string Initials, string UserName)
        {
            Customers Customer = new Customers()
            {
                Initials = Initials,
                PersonId = PersonId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = UserName,
                UpdatedBy = UserName,
                Deleted = false
            };

            return Customer;
        }

        private Persons MapPersonData(CustomersDto Customer)
        {
            Persons person = new Persons()
            {
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                EmailAddress = Customer.EmailAddress,
                Address = Customer.Address,
                CardId = Customer.CardId,
                PhoneNumber = Customer.PhoneNumber
            };

            return person;
        }

        public CurrencyExchangeDto GetACurrencyExchange(int local, int foreign)
        {
            try
            {
                CurrencyExchangeDto dto = new CurrencyExchangeDto();
                dto = this._CurrencyRepository.GetACurrencyExchange(local, foreign);
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
                List<ForeignCurrencyDropDto> list = new List<ForeignCurrencyDropDto>();
                list = this._CurrencyRepository.ListForeignCurrencies();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public LocalCurrencyDropDto GetALocalCurrencies()
        {
            try
            {
                LocalCurrencyDropDto dto = new LocalCurrencyDropDto();
                dto = this._CurrencyRepository.GetALocalCurrencies();
                return dto;
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
    }
}
