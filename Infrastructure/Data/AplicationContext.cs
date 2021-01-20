using HardwareStore.Core.Entities;
using HardwareStore.Core.Entities.Billing;
using HardwareStore.Core.Entities.Catalogs;
using HardwareStore.Core.Entities.ProductsAdmin;
using HardwareStore.Core.Entities.Security;
using HardwareStore.Core.Entities.Providers;
using HardwareStore.Core.Entities.SysConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareStore.Core.DTOs.Catalogs;
using HardwareStore.Core.DTOs.ProductsAdmin;

namespace HardwareStore.Infrastructure.Data
{
    public class AplicationContext : DbContext
    {
        public AplicationContext() : base("name=HardwareStoreEntities")
        {

        }

        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Configurations> Configurations { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<CurrencyExchange> CurrencyExchange { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<DetailProductStocks> DetailProductStocks { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<ForeignCurrencies> ForeignCurrencies { get; set; }
        public DbSet<LocalCurrencies> LocalCurrencies { get; set; }
        public DbSet<MaterialsTypes> MaterialsTypes { get; set; }
        public DbSet<MeasureUnits> MeasureUnits { get; set; }
        public DbSet<PendingTransfers> PendingTransfers { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductStocks> ProductStocks { get; set; }
        public DbSet<ProductTransfers> ProductTransfers { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public DbSet<PurchaseInvoices> PurchaseInvoices { get; set; }
        public DbSet<RemovedProducts> RemovedProducts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<SalesInvoices> SalesInvoices { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<TransfersDetails> TransfersDetails { get; set; }
        public DbSet<UnitConversions> UnitConversions { get; set; }
        public DbSet<UnitTypes> UnitTypes { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }

        //Not mapped objects...
        public DbSet<SuppliersDto> SuppliersDto { get; set; }
        public DbSet<ProductStocksDto> ProductStocksDto { get; set; }
        public DbSet<StocksDetailsDto> StocksDetailsDto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<SuppliersDto>();
            modelBuilder.Ignore<WarehousesDto>();
            modelBuilder.Entity<ProductStocksDto>().HasKey(x => x.LotNumber);
            modelBuilder.Entity<StocksDetailsDto>().HasKey(x => new { x.LotNumber, x.StocksCode });
        }
    }
}
