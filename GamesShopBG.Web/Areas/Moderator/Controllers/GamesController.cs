namespace GamesShopBG.Web.Areas.Moderator.Controllers
{
    using GamesShopBG.Services.Interfaces.Moderator;
    using GamesShopBG.Services.Models.Moderator;
    using GamesShopBG.Web.Controllers;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class GamesController : BaseModeratorController
    {
        private readonly IModeratorGamesService games;

        public GamesController(IModeratorGamesService games)
        {
            this.games = games;
        }

        public ActionResult Create()
            => this.View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEditFormServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await this.games.CreateAsync(model.Title,
                                         model.Price,
                                         model.Size,
                                         model.VideoId,
                                         model.ThumbnailUrl,
                                         model.Description,
                                         model.ReleaseDate);

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }
    }
}