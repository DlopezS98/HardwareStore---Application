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
                list = (from vendor in this._dbContext.Vendors
                        join supplier in this._dbContext.Suppliers
                        on vendor.SupplierId equals supplier.Id
                        join person in this._dbContext.Persons
                        on vendor.PersonId equals person.Id
                        where vendor.Deleted == false && supplier.Deleted == false
                        select new SuppliersDropDto
                        {
                            Id = supplier.Id,
                            Code = vendor.Code,
                            Name = supplier.Name + " - " + person.FullName
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
