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

        //GET: /Home/Index
        public async Task<ActionResult> Index(int page = 1)
            => this.View(new HomeIndexGamesListingsViewModel
            {
                Games = this.games.GetAllGames(page),
                TotalGames = await this.games.GetTotalAsync(),
                CurrentPage = page
            });

        //GET: /Home/Search/
        public ActionResult Search(HomeIndexGamesListingsViewModel model)
        {
            model.Games = this.games.Find(model.SearchText);

            return View(model);
        }
    }
}
