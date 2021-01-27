using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.SysConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces.Catalogs
{
    public interface IMeasureUnitsRepository
    {
        List<MeasureUnitsDropDto> ListMeasureUnitForDropdownsByType(int TypeId);
        TupleConversionDto GetConversionValueById(int From, int To);
    }
}
