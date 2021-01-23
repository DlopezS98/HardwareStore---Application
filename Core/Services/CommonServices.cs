using HardwareStore.Core.Interfaces;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Services
{
    public class CommonServices : ICommonServices
    {
        private readonly IMeasureUnitsRepository _UnitsRepository;
        public CommonServices(IMeasureUnitsRepository _UnitsRepository)
        {
            this._UnitsRepository = _UnitsRepository;
        }

        public string GetInitials(string Name)
        {
            try
            {
                string[] split = Name.Split(' ');
                string[] array = new string[split.Length];
                string initials;
                for (int i = 0; i < split.Length; i++)
                {
                    array[i] = split[i].Substring(0, 1);
                }

                initials = string.Concat(array);

                return initials;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public double GetConversionValue(int IdConvertFrom, int IdConvertTo, double? Value = null)
        {
            try
            {
                double ConversionValue = 0;

                if(Value != null)
                {
                    double BaseValue = this._UnitsRepository.GetConversionValueById(IdConvertFrom, IdConvertTo);
                    ConversionValue = (double)Value * BaseValue;
                }
                else
                {
                    ConversionValue = this._UnitsRepository.GetConversionValueById(IdConvertFrom, IdConvertTo);
                }

                return ConversionValue;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
