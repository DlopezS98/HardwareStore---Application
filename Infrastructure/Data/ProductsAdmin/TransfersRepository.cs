using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Interfaces.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.ProductsAdmin
{
    public class TransfersRepository : EntityRepository, ITransfersRepository
    {
        private SqlCommand Command;
        private readonly ApplicationContext _dbContext;
        public TransfersRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void CreateTranfer(ProductTransferDto dto)
        {
            try
            {
                Command = new SqlCommand();
                var Connection = this.GetConnection();
                Command.Connection = Connection;
                Command.CommandText = "[dbo].[Sp_CreateProductTransfers]";
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                Command.Parameters.AddWithValue("@TotalProducts", dto.TotalProducts);
                Command.Parameters.AddWithValue("@CreatedBy", dto.CreatedBy);
                Command.Parameters.AddWithValue("@UpdatedBy", dto.UpdatedBy);
                Command.Parameters.AddWithValue("@TransferStatus", dto.TranferStatus);
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void CreateTranfersDetails(List<PendingTranfersDto> Details)
        {
            try
            {
                if (Details.Count > 0)
                {
                    var Connection = this.GetConnection();
                    Connection.Open();
                    foreach (PendingTranfersDto e in Details)
                    {
                        Command = new SqlCommand();
                        Command.Connection = Connection;
                        Command.CommandText = "[dbo].[Sp_CreateTransferDetails]";
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@ProductStocksId", e.ProductStocksId);
                        Command.Parameters.AddWithValue("@LotNumber", e.LotNumber);
                        Command.Parameters.AddWithValue("@StocksCode", e.StocksCode);
                        Command.Parameters.AddWithValue("@TargetWarehouseId", e.TargetWarehouseId);
                        Command.Parameters.AddWithValue("@UnitBaseId", e.UnitBaseId);
                        Command.Parameters.AddWithValue("@TargetUnitId", e.TargetUnitId);
                        Command.Parameters.AddWithValue("@UnitQuantity", e.UnitQuantity);
                        Command.Parameters.AddWithValue("@UnitConversionId", e.UnitQuantity);
                        Command.Parameters.AddWithValue("@ConversionQuantity", e.ConversionQuantity);
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

        public List<TransfersDto> ListProductTransfer(string Search, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                List<TransfersDto> list = new List<TransfersDto>();
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter startdate = new SqlParameter("@StartDate", SqlDbType.VarChar); startdate.Direction = ParameterDirection.Input;
                SqlParameter enddate = new SqlParameter("@EndDate", SqlDbType.VarChar); enddate.Direction = ParameterDirection.Input;
                search.Value = Search;
                startdate.Value = StartDate.ToString("yyyy-MM-dd");
                enddate.Value = EndDate.ToString("yyyy-MM-dd");
                list = this._dbContext.Database.SqlQuery<TransfersDto>("EXEC [dbo].[Sp_ListProductsTransfer] @Search, @StartDate, @EndDate", search, startdate, enddate).ToList();
                return list;
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
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter transferid = new SqlParameter("@TransferId", SqlDbType.Int); search.Direction = ParameterDirection.Input;
                search.Value = Search;
                transferid.Value = TransferId;
                list = this._dbContext.Database.SqlQuery<TransferDetailsDto>("EXEC [dbo].[Sp_ListTransferDetails] @TransferId, @Search", transferid, search).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
