using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Entities.ProductsAdmin;
using HardwareStore.Core.Interfaces.ProductsAdmin;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
