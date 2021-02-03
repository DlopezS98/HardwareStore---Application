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
    public class RemovedProductsRepository : EntityRepository, IRemovedProductsRepository
    {
        private readonly ApplicationContext _dbContext;
        public RemovedProductsRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public List<RemovedProductsDto> GetRemovedProducts(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                List<RemovedProductsDto> list = new List<RemovedProductsDto>();
                SqlParameter search = new SqlParameter("@Search", SqlDbType.VarChar); search.Direction = ParameterDirection.Input;
                SqlParameter startdate = new SqlParameter("@StartDate", SqlDbType.VarChar); startdate.Direction = ParameterDirection.Input;
                SqlParameter enddate = new SqlParameter("@EndDate", SqlDbType.VarChar); enddate.Direction = ParameterDirection.Input;
                search.Value = Search;
                startdate.Value = StartDate.ToString("yyyy-MM-dd");
                enddate.Value = EndDate.ToString("yyyy-MM-dd");
                list = this._dbContext.Database.SqlQuery<RemovedProductsDto>("EXEC [dbo].[Sp_ListRemovedProducts] @StartDate, @EndDate,  @Search", startdate, enddate, search).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetDataTableRemovedProducts(DateTime StartDate, DateTime EndDate, string Search)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = string.Format("EXEC [dbo].[Sp_ListRemovedProducts] '{0}', '{1}',  '{2}'", StartDate.ToString("yyyy-MM-dd"), EndDate.ToString("yyyy-MM-dd"), Search);
                dt = this.GetInformation(query);
                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void RegisterRemovedProducts(RemovedProducts Rmprod)
        {
            try
            {
                this._dbContext.RemovedProducts.Add(Rmprod);
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
