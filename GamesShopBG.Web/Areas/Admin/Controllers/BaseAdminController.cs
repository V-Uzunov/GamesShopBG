namespace GamesShopBG.Web.Areas.Admin.Controllers
{
    using GamesShopBG.Common;
    using System.Web.Mvc;

    [RouteArea(GlobalConstants.AdminArea)]
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class BaseAdminController : Controller
    {
    }
}