using GamesShopBG.Web.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectConfig), "Stop")]

namespace GamesShopBG.Web.App_Start
{
    using GamesShopBG.Data;
    using GamesShopBG.Services.Implementations.Admin;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Services.Interfaces.Moderator;
    using GamesShopBG.Services.Implementations.Moderator;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Services.Implementations.Games;
    using GamesShopBG.Services.Implementations.ShoppingCart;

    public class NinjectConfig
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

            kernel
               .Bind<IAdminUserService>()
               .To<AdminUserService>()
               .InRequestScope();

            kernel
               .Bind<IModeratorGamesService>()
               .To<ModeratorGamesService>()
               .InRequestScope();

            kernel
                .Bind<IGameService>()
                .To<GameService>()
                .InRequestScope();
            
        }
    }
}