using HardwareStore.Core.DTOs.Catalogs;
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
        double GetConversionValueById(int From, int To);
    }
}
