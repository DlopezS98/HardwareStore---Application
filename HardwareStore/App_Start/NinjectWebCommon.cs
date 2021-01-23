[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HardwareStore.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HardwareStore.App_Start.NinjectWebCommon), "Stop")]

namespace HardwareStore.App_Start
{
    using System;
    using System.Web;
    using HardwareStore.Core.Interfaces;
    using HardwareStore.Core.Interfaces.Catalogs;
    using HardwareStore.Core.Interfaces.Billing;
    using HardwareStore.Core.Services.Billing;
    using HardwareStore.Infrastructure.Data;
    using HardwareStore.Infrastructure.Data.Catalogs;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using HardwareStore.Infrastructure.Data.Billing;
    using HardwareStore.Core.Interfaces.ProductsAdmin;
    using HardwareStore.Infrastructure.Data.ProductsAdmin;
    using HardwareStore.Core.Interfaces.SysConfiguration;
    using HardwareStore.Infrastructure.Data.SysConfiguration;
    using HardwareStore.Core.Services;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEntityRepository>().To<EntityRepository>();
            kernel.Bind<IProductsRepository>().To<ProductsRepository>();
            kernel.Bind<IPurchasesService>().To<PurchaseService>();
            kernel.Bind<IWarehouseRepository>().To<WarehouseRepository>();
            kernel.Bind<ISuppliersRepository>().To<SuppliersReporsitory>();
            kernel.Bind<IMeasureUnitsRepository>().To<MeasureUnitsRepository>();
            kernel.Bind<IPurchaseRepository>().To<PurchaseRepository>();
            kernel.Bind<IProductsStocksRepository>().To<ProductsStocksRepository>();
            kernel.Bind<ISalesServices>().To<SalesServices>();
            kernel.Bind<ICurrenciesRepository>().To<CurrenciesRepository>();
            kernel.Bind<ICommonServices>().To<CommonServices>();
        }
    }
}