namespace GamesShopBG.Web.Controllers
{
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Services.Models.Games;
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
        public PartialViewResult Search(string query)
        {
            var data = this.games.Find(query);

            return this.PartialView("_GamesListingPartial", data);
        }
    }
}
