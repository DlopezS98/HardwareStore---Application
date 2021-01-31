using HardwareStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces
{
    public interface IPersonsRepository
    {
        int CreateNewPerson(Persons person);
        void UpdatePersonInformation(int Id, Persons person);
    }
}
