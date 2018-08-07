[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GamesShopBG.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GamesShopBG.Web.App_Start.NinjectWebCommon), "Stop")]

namespace GamesShopBG.Web.App_Start
{
    using GamesShopBG.Auth;
    using GamesShopBG.Data;
    using GamesShopBG.Data.GamesShopBGData;
    using GamesShopBG.Services.Implementations.Admin;
    using GamesShopBG.Services.Implementations.Games;
    using GamesShopBG.Services.Implementations.Moderator;
    using GamesShopBG.Services.Implementations.ShoppingCart;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Services.Interfaces.Moderator;
    using GamesShopBG.Services.Interfaces.ShoppingCart;

    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    using System;
    using System.Data.Entity;
    using System.Web;

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
               .Bind<DbContext>()
               .To<GamesShopBGDbContext>()
               .InRequestScope();

            kernel.Bind<ISignInService>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            kernel.Bind<IUserService>().ToMethod(_ => HttpContext.Current.GetOwinContext().GetUserManager<UserManager>());

            kernel
                .Bind<IGamesShopBGData>()
                .To<GamesShopBGData>()
                .InRequestScope();

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

            kernel
                .Bind<IShoppingCartService>()
                .To<ShoppingCartService>()
                .InRequestScope();

        }
    }
}