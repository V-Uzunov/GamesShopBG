using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamesShopBG.Web.Startup))]
namespace GamesShopBG.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
