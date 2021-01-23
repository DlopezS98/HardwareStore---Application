using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces
{
    public interface ICommonServices
    {
        string GetInitials(string Name);
        double GetConversionValue(int IdConvertFrom, int IdConvertTo, double? Value);
    }
}
