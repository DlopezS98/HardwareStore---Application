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
        private readonly AplicationContext _dbContext;
        private SqlCommand Command;
        public ProductsStocksRepository(AplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
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
    }
}
