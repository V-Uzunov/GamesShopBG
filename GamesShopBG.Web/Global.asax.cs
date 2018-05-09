namespace GamesShopBG.Web
{
    using GamesShopBG.Data;
    using GamesShopBG.Data.Migrations;
    using GamesShopBG.Web.App_Start;
    using System.Data.Entity;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GamesShopBGDbContext, Configuration>());
            AutoMapperConfig.ConfigureAutomapper();
            
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
