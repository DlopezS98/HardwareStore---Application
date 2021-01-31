using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.Entities.Catalogs;
using HardwareStore.Core.Interfaces.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Infrastructure.Data.Catalogs
{
    public class WarehouseRepository : EntityRepository, IWarehouseRepository
    {
        private readonly ApplicationContext _dbContext;
        public WarehouseRepository(ApplicationContext _dbContext) : base(_dbContext)
        {
            this._dbContext = _dbContext;
        }

        public void CreateWarehouse(Warehouses warehouses)
        {
            try
            {
                this._dbContext.Warehouses.Add(warehouses);
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void DeleteWarehouse(int Id, string username)
        {
            try
            {
                Warehouses obj = new Warehouses();
                obj = this._dbContext.Warehouses.FirstOrDefault(x => x.Id == Id);
                obj.Deleted = true;
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = username;
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<WarehousesDto> GetWarehouses()
        {
            try
            {
                List<WarehousesDto> warehouses = new List<WarehousesDto>();
                var list = this._dbContext.Warehouses.Where(x => x.Deleted == false).ToList();
                warehouses = list.Select(x => new WarehousesDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Location = x.Location,
                    Code = x.Code,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    CreatedBy = x.CreatedBy,
                    UpdatedBy = x.UpdatedBy
                }).ToList();
                return warehouses;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public List<WarehousesDropDto> GetWarehousesForDropdownsList()
        {
            try
            {
                List<WarehousesDropDto> list = new List<WarehousesDropDto>();
                list = this._dbContext.Warehouses
                    .Where(x => x.Deleted == false)
                    .ToList()
                    .Select(x => new WarehousesDropDto()
                       {
                           Id = x.Id,
                           Name = x.Name
                       }).ToList();

                return list;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void UpdateWarehouse(int Id, WarehousesDto warehouses)
        {
            try
            {
                Warehouses obj = new Warehouses();
                obj = this._dbContext.Warehouses.FirstOrDefault(x => x.Id == Id);
                obj.Name = warehouses.Name;
                obj.Description = warehouses.Description;
                obj.Location = warehouses.Location;
                obj.UpdatedAt = DateTime.Now;
                obj.UpdatedBy = warehouses.UpdatedBy;
                this._dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
    }
}
