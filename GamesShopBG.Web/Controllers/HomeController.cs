namespace GamesShopBG.Web.Controllers
{
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Web.ViewModels.Home;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IGameService games;

        public HomeController(IGameService games)
        {
            this.games = games;
        }

        public ActionResult Index()
            => this.View(new HomeIndexViewModel
            {
                Games = this.games.GetAllGames()
            });

        public async Task<ActionResult> Search(HomeIndexViewModel model)
        {
            model.Games = await this.games.FindAsync(model.SearchText);

            return View(model);
        }

    }
}