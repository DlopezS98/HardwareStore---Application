using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.Interfaces
{
    public interface IEntityRepository
    {
        DataTable GetInformation(string Query);
        SqlConnection GetConnection();
    }
}
