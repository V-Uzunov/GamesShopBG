namespace GamesShopBG.Web.Controllers
{
    using GamesShopBG.Data;
    using GamesShopBG.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System.Web;
    using System.Web.Mvc;
    [Authorize]
    public abstract class BaseOrderController : Controller
    {
        protected UserManager userManager;
        protected GamesShopBGDbContext dbContext;

        public BaseOrderController()
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