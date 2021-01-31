using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.SysConfiguration;
using HardwareStore.Core.Entities.Catalogs;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Catalogs
{
    public class MeasureUnitsRepository : EntityRepository, IMeasureUnitsRepository
    {
        private readonly ApplicationContext _dbContext;
        public MeasureUnitsRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public List<MeasureUnitsDropDto> ListMeasureUnitForDropdownsByType(int TypeId)
        {
            try
            {
                List<MeasureUnitsDropDto> list = new List<MeasureUnitsDropDto>();
                var msu = this._dbContext.MeasureUnits.Where(x => x.UnitTypeId == TypeId);
                list = msu.Select(x => new MeasureUnitsDropDto() { Id = x.Id, Name = x.Name + " (" + x.Abbrevation + ")"}).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public TupleConversionDto GetConversionValueById(int From, int To)
        {
            try
            {
                TupleConversionDto dto = new TupleConversionDto();
                var data =  this._dbContext.UnitConversions.FirstOrDefault(x => x.IdMeasureUnitFrom == From && x.IdMeasureUnitTo == To);
                dto.Id = data.Id; dto.Value = data.ConversionValue;
                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
