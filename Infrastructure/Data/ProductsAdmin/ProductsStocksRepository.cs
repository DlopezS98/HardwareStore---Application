using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Entities.ProductsAdmin;
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
    public class ProductsStocksRepository : EntityRepository, IProductsStocksRepository
    {
        private readonly ApplicationContext _dbContext;
        private SqlCommand Command;
        public ProductsStocksRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public List<ProductStocksDto> GetProductStocks(string Search, bool Available, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                List<ProductStocksDto> list = new List<ProductStocksDto>();
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter available = new SqlParameter("@Available", SqlDbType.Bit); available.Direction = ParameterDirection.Input;
                SqlParameter startdate = new SqlParameter("@StartDate", SqlDbType.VarChar); startdate.Direction = ParameterDirection.Input;
                SqlParameter enddate = new SqlParameter("@EndDate", SqlDbType.VarChar); enddate.Direction = ParameterDirection.Input;
                search.Value = Search;
                available.Value = Available;
                startdate.Value = StartDate.ToString("yyyy-MM-dd");
                enddate.Value = EndDate.ToString("yyyy-MM-dd");
                list = this._dbContext.Database.SqlQuery<ProductStocksDto>("EXEC [dbo].[Sp_ListProductStocks] @Search, @Available, @StartDate, @EndDate", search, available, startdate, enddate).ToList();
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
                SqlParameter lotnumber = new SqlParameter("@LotNumber", SqlDbType.NVarChar); lotnumber.Direction = ParameterDirection.Input;
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter warehouseid = new SqlParameter("@WarehouseId", SqlDbType.Int); warehouseid.Direction = ParameterDirection.Input;
                lotnumber.Value = LotNumber;
                search.Value = Search;
                warehouseid.Value = WarehouseId;
                list = this._dbContext.Database.SqlQuery<StocksDetailsDto>("[dbo].[Sp_ListProductStocksDetails] @LotNumber, @Search, @WarehouseId", lotnumber, search, warehouseid).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public StocksDetailsDto GetStocksDetail(string StocksCode)
        {
            try
            {
                StocksDetailsDto details = new StocksDetailsDto();
                List<StocksDetailsDto> data = this.GetProductStocksDetails("0", "", 0);
                details = data.FirstOrDefault(x => x.StocksCode == StocksCode);
                return details;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void UpdateStocksDetails(List<StocksUpdateDto> dto)
        {
            try
            {
                if(dto.Count > 0)
                {
                    foreach (StocksUpdateDto stocks in dto)
                    {
                        DetailProductStocks details = this._dbContext.DetailProductStocks.FirstOrDefault(x => x.Code == stocks.StockCode);
                        details.Quantity = stocks.UnitPurchasedQuantity;
                        details.ConversionQuantity = stocks.UnitBaseQuantity;
                        if(stocks.UnitPurchasedQuantity <= 0)
                        {
                            details.Available = false;
                        }

                        this._dbContext.SaveChanges();
                    }

                    this.UpdateProductStocks(dto);
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        private void UpdateProductStocks(List<StocksUpdateDto> dto)
        {
            try
            {
                foreach (StocksUpdateDto item in dto)
                {
                    ProductStocks stocks = this._dbContext.ProductStocks.FirstOrDefault(x => x.LotNumber == item.LotNumber);
                    int availables = this._dbContext.DetailProductStocks.Where(x => x.ProductStocksId == stocks.Id && x.Available == true).ToList().Count;
                    if (availables < 1)
                    {
                        stocks.Available = false;
                        this._dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void RegisterNewProductStocks(ProductStocks Product)
        {
            try
            {
                Command = new SqlCommand();
                var Connection = this.GetConnection();
                Command.Connection = Connection;
                Command.CommandText = "[dbo].[Sp_CreateProductStocks]";
                Command.CommandType = CommandType.StoredProcedure;
                Connection.Open();
                Command.Parameters.AddWithValue("@SupplierId", Product.SupplierId);
                Command.Parameters.AddWithValue("@Quantity", Product.Quantity);
                Command.Parameters.AddWithValue("@TotalAmount", Product.TotalAmount);
                Command.Parameters.AddWithValue("@UserName", Product.CreatedBy);
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void RegisterProductStocksDetails(List<DetailProductStocks> Details)
        {
            try
            {
                if (Details.Count > 0)
                {
                    var Connection = this.GetConnection();
                    Connection.Open();
                    foreach (DetailProductStocks e in Details)
                    {
                        Command = new SqlCommand();
                        Command.Connection = Connection;
                        Command.CommandText = "[dbo].[Sp_CreateDetailProductStocks]";
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@ProductDetailCode", e.ProductDetailCode);
                        Command.Parameters.AddWithValue("@WarehouseId", e.WarehouseId);
                        Command.Parameters.AddWithValue("@TargetUnitId", e.TargetUnitId);
                        Command.Parameters.AddWithValue("@Quantity", e.Quantity);
                        Command.Parameters.AddWithValue("@PurchasePrice", e.PurchasePrice);
                        Command.Parameters.AddWithValue("@SalePrice", e.SalePrice);
                        Command.Parameters.AddWithValue("@ExpirationDate", e.ExpirationDate);
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

        public DataTable GetDataTableProductStocks(string Search, bool Available, DateTime StartDate, DateTime EndDate)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter available = new SqlParameter("@Available", SqlDbType.Bit); available.Direction = ParameterDirection.Input;
                SqlParameter startdate = new SqlParameter("@StartDate", SqlDbType.VarChar); startdate.Direction = ParameterDirection.Input;
                SqlParameter enddate = new SqlParameter("@EndDate", SqlDbType.VarChar); enddate.Direction = ParameterDirection.Input;
                search.Value = Search;
                available.Value = Available;
                startdate.Value = StartDate.ToString("yyyy-MM-dd");
                enddate.Value = EndDate.ToString("yyyy-MM-dd");
                dt = this._dbContext.Database.SqlQuery<DataTable>("EXEC [dbo].[Sp_ListProductStocks] @Search, @Available, @StartDate, @EndDate", search, available, startdate, enddate).FirstOrDefault();
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
