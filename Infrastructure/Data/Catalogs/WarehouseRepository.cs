using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Catalogs
{
    public class WarehouseRepository : EntityRepository, IWarehouseRepository
    {
        private readonly AplicationContext _dbContext;
        public WarehouseRepository(AplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public List<WarehousesDropDto> GetWarehousesForDropdownsList()
        {
            try
            {
                List<WarehousesDropDto> list = new List<WarehousesDropDto>();
                list = this._dbContext.Warehouses.Select(x => new WarehousesDropDto()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
