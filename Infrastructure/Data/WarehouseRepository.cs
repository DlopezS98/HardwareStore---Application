using HardwareStore.Core.DTOs.Warehouses;
using HardwareStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data
{
    public class WarehouseRepository : EntityRepository, IWarehouseRepository
    {
        private readonly AplicationContext Context;
        public WarehouseRepository(AplicationContext Context) : base(Context)
        {
            this.Context = Context;
        }

        public List<WarehousesDropDto> GetWarehousesForDropdownsList()
        {
            try
            {
                List<WarehousesDropDto> list = new List<WarehousesDropDto>();
                list = this.Context.Warehouses.Select(x => new WarehousesDropDto()
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
