using FastMember;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.SysConfiguration;
using HardwareStore.Core.Interfaces;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Data;
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

        public TupleConversionDto GetConversionValue(int IdConvertFrom, int IdConvertTo, double? Value = null)
        {
            try
            {
                TupleConversionDto dto = new TupleConversionDto();

                if(Value != null)
                {
                    dto = this._UnitsRepository.GetConversionValueById(IdConvertFrom, IdConvertTo);
                    dto.Value = (double)Value * dto.Value;
                }
                else
                {
                    dto = this._UnitsRepository.GetConversionValueById(IdConvertFrom, IdConvertTo);
                }

                return dto;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        //Mapear lista y retornar en datatable
        public DataTable ToDataTable<T>(IEnumerable<T> list)
        {
            DataTable dt = new DataTable();
            using (var reader = ObjectReader.Create(list))
            {
                dt.Load(reader);
            }

            return dt;
        }

        //public DataTable test()
        //{
        //    var list = this._UnitsRepository.ListMeasureUnitForDropdownsByType(1);
        //    DataTable dt = this.ToDataTable(list);
        //    return dt;
        //}
    }
}
