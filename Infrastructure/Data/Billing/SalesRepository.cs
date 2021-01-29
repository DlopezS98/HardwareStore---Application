using HardwareStore.Core.DTOs.Billing;
using HardwareStore.Core.Entities.Billing;
using HardwareStore.Core.Interfaces.Billing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Billing
{
    public class SalesRepository : EntityRepository, ISalesRepository
    {

        private SqlCommand Command;
        private readonly ApplicationContext _dbContext;
        public SalesRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void CreateInvoiceDetails(List<SalesDetails> Details)
        {
            try
            {
                if (Details.Count > 0)
                {
                    var Connection = this.GetConnection();
                    Connection.Open();
                    foreach (SalesDetails e in Details)
                    {
                        Command = new SqlCommand();
                        Command.Connection = Connection;
                        Command.CommandText = "[dbo].[Sp_CreateSaleDetailInvoice]";
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@StockLotNumber", e.StockLotNumber);
                        Command.Parameters.AddWithValue("@ProductDetailCode", e.ProductDetailCode);
                        Command.Parameters.AddWithValue("@WarehouseId", e.WarehouseId);
                        Command.Parameters.AddWithValue("@SaleUnitId", e.SaleUnitId);
                        Command.Parameters.AddWithValue("@PurchasedUnitId", e.PurchasedUnitId);
                        Command.Parameters.AddWithValue("@UnitConversionId", e.UnitConversionId);
                        Command.Parameters.AddWithValue("@ConversionValue", e.ConversionValue);
                        Command.Parameters.AddWithValue("@Quantity", e.Quantity);
                        Command.Parameters.AddWithValue("@Price", e.Price);
                        Command.Parameters.AddWithValue("@Subtotal", e.Subtotal);
                        Command.Parameters.AddWithValue("@Tax", e.Tax);
                        Command.Parameters.AddWithValue("@Discount", e.Discount);
                        Command.Parameters.AddWithValue("@Total", e.Total);
                        Command.ExecuteNonQuery();
                    }
                    Connection.Close();
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void CreateSaleInvoice(SalesInvoices Invoice)
        {
            try
            {
                Command = new SqlCommand();
                var Connection = this.GetConnection();
                Command.Connection = Connection;
                Command.CommandText = "[dbo].[Sp_CreateSaleInvoice]";
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                Command.Parameters.AddWithValue("@CustomerId", Invoice.CustomerId);
                Command.Parameters.AddWithValue("@CustomerInvoice", Invoice.CustomerInvoice);
                Command.Parameters.AddWithValue("@CurrencyExchangeId", Invoice.CurrencyExchangeId);
                Command.Parameters.AddWithValue("@Payment", Invoice.Payment);
                Command.Parameters.AddWithValue("@PaymentChange", Invoice.PaymentChange);
                Command.Parameters.AddWithValue("@Tax", Invoice.Tax);
                Command.Parameters.AddWithValue("@Subtotal", Invoice.Subtotal);
                Command.Parameters.AddWithValue("@Discount", Invoice.Discount);
                Command.Parameters.AddWithValue("@TotalAmount", Invoice.TotalAmount);
                Command.Parameters.AddWithValue("@UserName", Invoice.CreatedBy);
                Command.ExecuteNonQuery();
                Connection.Close();
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
                SqlParameter invoiceid = new SqlParameter("@InvoiceId", SqlDbType.Int); invoiceid.Direction = ParameterDirection.Input;
                invoiceid.Value = InvoiceId;
                list = this._dbContext.Database.SqlQuery<SalesDetailsDto>("[dbo].[Sp_ListSalesDetails] @InvoiceId", invoiceid).ToList();
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
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter startdate = new SqlParameter("@StartDate", SqlDbType.VarChar); startdate.Direction = ParameterDirection.Input;
                SqlParameter enddate = new SqlParameter("@EndDate", SqlDbType.VarChar); enddate.Direction = ParameterDirection.Input;
                search.Value = Search;
                startdate.Value = StartDate.ToString("yyyy-MM-dd");
                enddate.Value = EndDate.ToString("yyyy-MM-dd");
                list = this._dbContext.Database.SqlQuery<SalesInvoiceDto>("EXEC [dbo].[Sp_ListSaleInvoices] @Search, @StartDate, @EndDate", search, startdate, enddate).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
