namespace GamesShopBG.Web.Controllers
{
    using GamesShopBG.Services.Interfaces.Games;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class GamesController : Controller
    {
        private readonly IGameService games;

        public GamesController(IGameService games)
        {
            this.games = games;
        }

        //GET: /Games/Details/{id}
        public async Task<ActionResult> Details(int id)
        {
            var gamesWithId = await this.games.FindByIdAsync(id);

            if (gamesWithId == null)
            {
                return this.HttpNotFound();
            }

            return this.View(gamesWithId);
        }
    }
}