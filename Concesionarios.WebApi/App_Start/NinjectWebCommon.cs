[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Concesionarios.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Concesionarios.WebApi.App_Start.NinjectWebCommon), "Stop")]

namespace Concesionarios.WebApi.App_Start
{
    using Concesionarios.DAL;
    using Concesionarios.DAL.Repository;
    using Concesionarios.DAL.Repository.Common;
    using Concesionarios.Service;
    using Concesionarios.Service.Common;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using System;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
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
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
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
            //kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            //kernel.Bind<IConcesionariosDbContext>().To<ConcesionariosDbContext>().InRequestScope();
            kernel.Bind<DbContext>().To<ConcesionariosDbContext>().InRequestScope();
            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
            kernel.Bind<IConcesionarioRepository>().To<ConcesionarioRepository>().InRequestScope();
            kernel.Bind<ICocheRepository>().To<CocheRepository>().InRequestScope();
            kernel.Bind<IMarcaRepository>().To<MarcaRepository>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(IEntityService<>)).To(typeof(EntityService<>)).InRequestScope();
            kernel.Bind<IConcesionarioService>().To<ConcesionarioService>().InRequestScope();
            kernel.Bind<ICocheService>().To<CocheService>().InRequestScope();
            kernel.Bind<IMarcaService>().To<MarcaService>().InRequestScope();
            //// unit of work per request
            //kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            //// default binding for everything except unit of work
            //kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().Excluding<UnitOfWork>().BindDefaultInterface());

        }
    }
}
