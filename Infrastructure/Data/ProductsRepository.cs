using HardwareStore.Core.DTOs.Products;
using HardwareStore.Core.Interfaces;
using HardwareStore.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data
{
    public class ProductsRepository : EntityRepository, IProductsRepository
    {
        private readonly HardwareStoreEntities Context;
        public ProductsRepository(HardwareStoreEntities Context) : base(Context)
        {
            this.Context = Context;
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

        public List<ProductDetailsDto> ListAllProducts(bool Deleted, string Search)
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

        public List<ProductDetailsDto> ListAllProducts()
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
