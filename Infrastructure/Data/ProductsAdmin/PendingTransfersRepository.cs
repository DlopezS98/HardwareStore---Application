using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Entities;
using HardwareStore.Core.Entities.ProductsAdmin;
using HardwareStore.Core.Interfaces.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareStore.Core.Entities.Enums;

namespace HardwareStore.Infrastructure.Data.ProductsAdmin
{
    public class PendingTransfersRepository : EntityRepository, IPendingTransfersRepository
    {
        private SqlCommand Command;
        private readonly ApplicationContext _dbContext;
        public PendingTransfersRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void CreatePendingTransfer(PendingTranfersModelDto dto)
        {
            try
            {
                Command = new SqlCommand();
                var Connection = this.GetConnection();
                Command.Connection = Connection;
                Command.CommandText = "[dbo].[Sp_CreatePendingTransfers]";
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                Command.Parameters.AddWithValue("@ProductStocksId", dto.ProductStocksId);
                Command.Parameters.AddWithValue("@LotNumber", dto.LotNumber);
                Command.Parameters.AddWithValue("@StocksCode", dto.StocksCode);
                Command.Parameters.AddWithValue("@ProductDetailCode", dto.ProductDetailCode);
                Command.Parameters.AddWithValue("@WarehouseId", dto.WarehouseId);
                Command.Parameters.AddWithValue("@TargetWarehouseId", dto.TargetWarehouseId);
                Command.Parameters.AddWithValue("@TargetUnitId", dto.TargetUnitId);
                Command.Parameters.AddWithValue("@PurchasedUnitId", dto.PurchasedUnitId);
                Command.Parameters.AddWithValue("@UnitQuantity", dto.UnitQuantity);
                Command.Parameters.AddWithValue("@UnitTypeId", dto.UnitTypeId);
                Command.Parameters.AddWithValue("@UserName", dto.UserName);
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void UpdateProductStatusInTransferList(string Code, string User, TransferStatus status)
        {
            try
            {
                PendingTransfers pdt = new PendingTransfers();
                pdt = this._dbContext.PendingTransfers.FirstOrDefault(x => x.Code == Code);
                pdt.TransferStatus = status;
                pdt.UpdatedBy = User;
                pdt.UpdatedAt = DateTime.Now;
                this._dbContext.SaveChanges();
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
                dto = this.GetPendingTransferProducts("", Enums.TransferStatus.All).FirstOrDefault(x => x.Code == Code);
                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<PendingTranfersDto> GetPendingTransferProducts(string Search, Enums.TransferStatus Status)
        {
            try
            {
                List<PendingTranfersDto> list = new List<PendingTranfersDto>();
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter status = new SqlParameter("@TransferStatus", SqlDbType.Int); status.Direction = ParameterDirection.Input;
                search.Value = Search;
                status.Value = Convert.ToInt32(Status);
                list = this._dbContext.Database.SqlQuery<PendingTranfersDto>("EXEC [dbo].[Sp_ListPendingTransfer] @Search, @TransferStatus", search, status).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetDataTablePendingTransferProducts(string Search, Enums.TransferStatus Status)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = string.Format("EXEC [dbo].[Sp_ListPendingTransfer] '{0}', {1}", Search, Status);
                dt = this.GetInformation(query);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void UpdatePendingTranfer(string Code, PendingTranfersModelDto dto)
        {
            try
            {
                Command = new SqlCommand();
                var Connection = this.GetConnection();
                Command.Connection = Connection;
                Command.CommandText = "[dbo].[Sp_UpdatePendingTransfer]";
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                Command.Parameters.AddWithValue("@Code", Code);
                Command.Parameters.AddWithValue("@TargetWarehouseId", dto.TargetWarehouseId);
                Command.Parameters.AddWithValue("@TargetUnitId", dto.TargetUnitId);
                Command.Parameters.AddWithValue("@UnitQuantity", dto.UnitQuantity);
                Command.Parameters.AddWithValue("@UserName", dto.UserName);
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
