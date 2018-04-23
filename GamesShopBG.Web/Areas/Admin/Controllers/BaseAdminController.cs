namespace GamesShopBG.Web.Areas.Admin.Controllers
{
    using GamesShopBG.Common;
    using GamesShopBG.Data;
    using GamesShopBG.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System.Web;
    using System.Web.Mvc;

    [RouteArea(GlobalConstants.AdminArea)]
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class BaseAdminController : Controller
    {
        protected UserManager userManager;
        protected GamesShopBGDbContext dbContext;
        public BaseAdminController(GamesShopBGDbContext dbContext)
        {
            this.userManager = new UserManager(
                new UserStore<User>(dbContext));
            this.dbContext = GamesShopBGDbContext.Create();
        }
        protected UserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            }
            private set
            {
                userManager = value;
            }
        }
    }
}