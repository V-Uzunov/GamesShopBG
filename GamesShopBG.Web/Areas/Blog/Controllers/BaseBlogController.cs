namespace GamesShopBG.Web.Areas.Blog.Controllers
{
    using GamesShopBG.Common;
    using System.Web.Mvc;

    [RouteArea(GlobalConstants.BlogArea)]
    [Authorize(Roles = GlobalConstants.BlogAuthor)]
    public class BaseBlogController : Controller
    {
    }
}