using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Catalogs
{
    public class SuppliersReporsitory : EntityRepository, ISuppliersRepository
    {
        private readonly AplicationContext _dbContext;
        public SuppliersReporsitory(AplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public List<SuppliersDropDto> ListSuppliersForDropDowns()
        {
            try
            {
                List<SuppliersDropDto> list = new List<SuppliersDropDto>();
                list = this._dbContext.Suppliers.Select(x => new SuppliersDropDto() { Id = x.Id, Name = x.Name, Code = x.Code }).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
