using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Catalogs
{
    public class ProductsRepository : EntityRepository, IProductsRepository
    {
        private readonly ApplicationContext _dbContext;
        public ProductsRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public ProductDetailsDto GetAProductDetail(string Code)
        {
            try
            {
                ProductDetailsDto dto = new ProductDetailsDto();
                List<ProductDetailsDto> list = new List<ProductDetailsDto>();
                list = this.ListAllProductDetails();
                dto = list.FirstOrDefault(x => x.Code == Code);
                return dto;
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
                string query = string.Format("EXEC [dbo].[Sp_ListProductsDetails] {0}, '{1}'", Deleted, Search);
                DataTable dt = this.GetInformation(query);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<ProductDetailsDto> ListAllProductDetails(bool Deleted, string Search)
        {
            try
            {
                List<ProductDetailsDto> list = new List<ProductDetailsDto>();
                DataTable dt = this.GetProductDetailsFromDatabase(Deleted, Search);
                list = ConvertDataTableToList<ProductDetailsDto>(dt);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        //public DataTable GetDataTableProductStocks(bool Deleted, string Search)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
        //        SqlParameter deleted = new SqlParameter("@Deleted", SqlDbType.Bit); deleted.Direction = ParameterDirection.Input;
        //        search.Value = Search;
        //        deleted.Value = Deleted;
        //        dt = this._dbContext.Database.SqlQuery<DataTable>("EXEC [dbo].[Sp_ListProductStocks] @Deleted, @Search", deleted, search).FirstOrDefault();
        //        return dt;
        //    }
        //    catch (Exception exc)
        //    {

        //        throw exc;
        //    }
        //}

        public List<ProductDetailsDto> ListAllProductDetails()
        {
            try
            {
                List<ProductDetailsDto> list = new List<ProductDetailsDto>();
                DataTable dt = this.GetProductDetailsFromDatabase(false, "");
                list = ConvertDataTableToList<ProductDetailsDto>(dt);
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
