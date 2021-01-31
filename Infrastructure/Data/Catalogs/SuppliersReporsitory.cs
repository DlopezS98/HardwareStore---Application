using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Entities.Providers;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Catalogs
{
    public class SuppliersReporsitory : EntityRepository, ISuppliersRepository
    {
        private readonly ApplicationContext _dbContext;
        public SuppliersReporsitory(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void CreateSupplier(Suppliers suppliers)
        {
            try
            {
                this._dbContext.Suppliers.Add(suppliers);
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void DeleteSupplier(int Id, string username)
        {
            try
            {
                Suppliers sp = new Suppliers();
                sp = this._dbContext.Suppliers.FirstOrDefault(x => x.Id == Id);
                sp.Deleted = true;
                sp.UpdatedAt = DateTime.Now;
                sp.UpdatedBy = username;
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<SuppliersDto> GetSuppliers(string search)
        {
            try
            {
                List<SuppliersDto> list = new List<SuppliersDto>();
                SqlParameter Search = new SqlParameter("@Search", SqlDbType.VarChar); Search.Direction = ParameterDirection.Input;
                Search.Value = search;
                list = this._dbContext.Database.SqlQuery<SuppliersDto>("EXEC [dbo].[Sp_ListSuppliers] @Search", Search).ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<SuppliersDropDto> ListSuppliersForDropDowns()
        {
            try
            {
                List<SuppliersDropDto> list = new List<SuppliersDropDto>();
                list = this._dbContext.Suppliers
                        .Where(x => x.Deleted == false)
                        .ToList()
                        .Select(x => new SuppliersDropDto() { Id = x.Id, Name = x.Name, Code = x.Code })
                        .ToList();
                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void UpdateSupplier(int Id, SuppliersDto suppliers)
        {
            try
            {
                Suppliers sp = new Suppliers();
                sp = this._dbContext.Suppliers.FirstOrDefault(x => x.Id == Id);
                sp.Name = suppliers.Name;
                sp.Email = suppliers.Name;
                sp.Address = suppliers.Address;
                sp.UpdatedAt = DateTime.Now;
                sp.UpdatedBy = suppliers.UpdatedBy;
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
