using HardwareStore.Core.Interfaces;
using HardwareStore.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data
{
    public class EntityRepository : IEntityRepository
    {
        private readonly HardwareStoreEntities Context;
        public EntityRepository(HardwareStoreEntities Context)
        {
            this.Context = Context;
        }
        public SqlConnection GetConnection()
        {
            try
            {
                string StringConnection = @"" + this.Context.Database.Connection.ConnectionString;
                return new SqlConnection(StringConnection);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public DataTable GetInformation(string Query)
        {
            try
            {
                var Connection = this.GetConnection();
                DataTable dt = new DataTable();
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = Query;
                command.CommandTimeout = 150;
                var response = command.ExecuteReader();
                dt.Load(response);
                command.Dispose();
                Connection.Close();

                return dt;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }

            return obj;
        }
    }
}
