using HardwareStore.Core.DTOs.Catalogs;
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
        private readonly AplicationContext _dbContext;
        public MeasureUnitsRepository(AplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public List<MeasureUnitsDropDto> ListMeasureUnitForDropdownsByType(int TypeId)
        {
            try
            {
                List<MeasureUnitsDropDto> list = new List<MeasureUnitsDropDto>();
                var msu = this._dbContext.MeasureUnits.Where(x => x.UnitTypeId == TypeId);
                list = msu.Select(x => new MeasureUnitsDropDto() { Id = x.Id, Name = x.Name + " - " + x.Abbrevation}).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public double GetConversionValueById(int From, int To)
        {
            try
            {
                //string query = string.Format("SELECT * FROM UnitConversion WHERE IdMeasureUnitFrom = {0} AND IdMeasureUnitTo = {1}", From, To);
                /*this._dbContext.Database.SqlQuery<UnitConversion>(query).First();*/
                var conversion =  this._dbContext.UnitConversions.FirstOrDefault(x => x.IdMeasureUnitFrom == From && x.IdMeasureUnitTo == To);
                return conversion.ConversionValue;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
