using HardwareStore.Core.DTOs;
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
    public class PurchaseRepository : EntityRepository, IPurchaseRepository
    {
        private SqlCommand Command;
        private readonly AplicationContext _dbContext;

        public PurchaseRepository(AplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void CreateNewPurchase(PurchaseInvoices Invoice)
        {
            try
            {
                Command = new SqlCommand();
                var Connection = this.GetConnection();
                Command.Connection = Connection;
                Command.CommandText = "[dbo].[Sp_CreatePurchaseInvoices]";
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                Command.Parameters.AddWithValue("@SupplierId", Invoice.SupplierId);
                Command.Parameters.AddWithValue("@SupplierInvoiceNumber", Invoice.SupplierInvoiceNumber);
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

        public void CreatePurchaseDetails(List<PurchaseDetails> Details)
        {
            try
            {
                if (Details.Count > 0)
                {
                    var Connection = this.GetConnection();
                    Connection.Open();
                    foreach (PurchaseDetails e in Details)
                    {
                        Command = new SqlCommand();
                        Command.Connection = Connection;
                        Command.CommandText = "[dbo].[Sp_CreatePurchaseDetails]";
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@ProductDetailCode", e.ProductDetailCode);
                        Command.Parameters.AddWithValue("@WarehouseId", e.WarehouseId);
                        Command.Parameters.AddWithValue("@TargetUnitId", e.TargetUnitId);
                        Command.Parameters.AddWithValue("@Quantity", e.Quantity);
                        Command.Parameters.AddWithValue("@PurchasePrice", e.PurchasePrice);
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

        public List<InvoicesDto> GetPurhaseInvoices(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                List<InvoicesDto> Invoices = new List<InvoicesDto>();
                DataTable dt = this.GetPurchaseInvoicesFromDataBase(StartDate, EndDate, Search);
                Invoices = ConvertDataTableToList<InvoicesDto>(dt);
                return Invoices;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetPurchaseInvoicesFromDataBase(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                string query;
                query = string.Format("EXEC [dbo].[Sp_ListPurchaseInvoices] '{0}', '{1}', '{2}'", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), Search);
                DataTable dt = this.GetInformation(query);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetPurchaseInvoiceDetailsFromDataBase(int InvoiceId)
        {
            try
            {
                string query = string.Format("[dbo].[Sp_GetInvoiceDetails] {0}", InvoiceId);
                DataTable dt = this.GetInformation(query);
                return dt;
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
                List<InvoiceDetailsDto> Details = new List<InvoiceDetailsDto>();
                DataTable dt = this.GetPurchaseInvoiceDetailsFromDataBase(InvoiceId);
                Details = ConvertDataTableToList<InvoiceDetailsDto>(dt);
                return Details;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
