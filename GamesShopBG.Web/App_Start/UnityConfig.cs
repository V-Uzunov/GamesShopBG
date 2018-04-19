namespace GamesShopBG.Web
{
    using GamesShopBG.Data;
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Implementations.Admin;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Web.Controllers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Web.Mvc;
    using Unity;
    using Unity.Injection;
    using Unity.Lifetime;
    using Unity.Mvc5;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<DbContext, GamesShopBGDbContext>(
    new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<User>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<User>, UserStore<User>>(
                new HierarchicalLifetimeManager());

            container.RegisterType<AccountController>(
                new InjectionConstructor());
            container.RegisterType<IAdminUserService, AdminUserService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}