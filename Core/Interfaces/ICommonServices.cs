using HardwareStore.Core.DTOs.SysConfiguration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces
{
    public interface ICommonServices
    {
        string GetInitials(string Name);
        TupleConversionDto GetConversionValue(int IdConvertFrom, int IdConvertTo, double? Value);
        DataTable ToDataTable<T>(IList data);
    }
}
