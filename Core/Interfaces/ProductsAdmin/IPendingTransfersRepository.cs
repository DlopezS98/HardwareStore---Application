using HardwareStore.Core.DTOs.ProductsAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareStore.Core.Entities.Enums;

namespace HardwareStore.Core.Interfaces.ProductsAdmin
{
    public interface IPendingTransfersRepository
    {
        void CreatePendingTransfer(PendingTranfersModelDto dto);
        void UpdatePendingTranfer(string Code, PendingTranfersModelDto dto);
        void UpdateProductStatusInTransferList(string Code, string User, TransferStatus status);
        List<PendingTranfersDto> GetPendingTransferProducts(string Search, TransferStatus Status);
        PendingTranfersDto GetPendingTransferProduct(string Code);
        DataTable GetDataTablePendingTransferProducts(string Search, TransferStatus Status);
    }
}
