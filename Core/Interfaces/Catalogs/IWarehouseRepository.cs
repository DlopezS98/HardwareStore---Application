using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Catalogs
{
    public interface IWarehouseRepository
    {
        List<WarehousesDropDto> GetWarehousesForDropdownsList();
        List<WarehousesDto> GetWarehouses();
        void CreateWarehouse(Warehouses warehouses);
        void UpdateWarehouse(int Id, WarehousesDto warehouses);
        void DeleteWarehouse(int Id, string username);
    }
}
