using HardwareStore.Core.DTOs.ProductsAdmin;
using HardwareStore.Core.Entities.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.ProductsAdmin
{
    public interface IRemovedProductsRepository
    {
        void RegisterRemovedProducts(RemovedProducts Rmprod);
        List<RemovedProductsDto> GetRemovedProducts(DateTime StartDate, DateTime EndDate, string Search);
    }
}
