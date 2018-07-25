namespace GamesShopBG.Web.Areas.Moderator.Controllers
{
    using Services.Interfaces.Moderator;
    using Services.Models.Moderator;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Web.Controllers;
    using Web.Infrastructure.Extensions;

    public class GamesController : BaseModeratorController
    {
        private readonly IModeratorGamesService games;

        public GamesController(IModeratorGamesService games)
        {
            this.games = games;
        }

        //GET: /Moderator/Games/Create
        public ActionResult Create()
            => this.View();

        //POST: /Moderator/Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeratorGameServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            this.games.Create(model);

            TempData.AddSuccessMessage($"Game {model.Title} was created successful!");

            return this.RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        //GET: /Moderator/Games/Edit/{id}
        public async Task<ActionResult> Edit(int id)
        {
            var game = await this.games.FindByIdAsync(id);

            if (game == null)
            {
                return HttpNotFound();
            }

            return this.View(new ModeratorGameServiceModel
            {
                Id = game.Id,
                Title = game.Title,
                Price = game.Price,
                Size = game.Size,
                Description = game.Description,
                ThumbnailUrl = game.ThumbnailUrl,
                ReleaseDate = game.ReleaseDate,
                VideoUrl = game.VideoUrl
            });
        }

        //POST: /Moderator/Games/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeratorGameServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            this.games.EditGame(model);

            TempData.AddSuccessMessage($"Game {model.Title} was edited successful!");

            return this.RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        //GET: /Moderator/Games/Delete/{id}
        public async Task<ActionResult> Delete(int id)
        {
            var game = await this.games.FindByIdAsync(id);

            if (game == null)
            {
                return this.HttpNotFound();
            }

            return this.View(new ModeratorGameServiceModel
            {
                Id = game.Id,
                Title = game.Title,
                Price = game.Price,
                Size = game.Size,
                Description = game.Description,
                ThumbnailUrl = game.ThumbnailUrl,
                ReleaseDate = game.ReleaseDate,
                VideoUrl = game.VideoUrl
            });
        }

        //POST: /Moderator/Games/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(int id)
        {
            var game = await this.games.FindByIdAsync(id);

            if (game == null)
            {
                return this.HttpNotFound();
            }

            this.games.Delete(id);

            TempData.AddErrorMessage($"Game {game.Title} was deleted successful!");

            return this.RedirectToAction(nameof(HomeController.Index),
                    "Home",
                    new { area = string.Empty });
        }
    }
}
