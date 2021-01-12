using HardwareStore.Core.DTOs.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces
{
    public interface IWarehouseRepository
    {
        List<WarehousesDropDto> GetWarehousesForDropdownsList();
    }
}
