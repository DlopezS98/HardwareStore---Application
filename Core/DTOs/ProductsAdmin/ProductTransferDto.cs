using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HardwareStore.Core.Entities.Enums;

namespace HardwareStore.Core.DTOs.ProductsAdmin
{
    public class ProductTransferDto
    {
        public string Code { get; set; }
        public int TotalProducts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public TransferStatus TranferStatus { get; set; }
    }
}
