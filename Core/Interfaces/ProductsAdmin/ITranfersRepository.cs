using HardwareStore.Core.DTOs.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.ProductsAdmin
{
    public interface ITranfersRepository
    {
        void CreateTranfer(ProductTransferDto dto);
        void CreateTranfersDetails(List<PendingTranfersDto> list);
        List<PendingTranfersDto> ListTransfers(string Search);
    }
}
