using GamesShopBG.Common;
using System.Web.Mvc;

namespace GamesShopBG.Web.Areas.Moderator.Controllers
{
    [RouteArea(GlobalConstants.ModeratorArea)]
    [Authorize(Roles = GlobalConstants.ModeratorRole)]
    public abstract class BaseModeratorController : Controller
    {
    }
}