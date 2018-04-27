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

        //GET: /Moderator/Game/Create
        public ActionResult Create()
            => this.View();

        //POST: /Moderator/Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModeratorGameServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await this.games.CreateAsync(model.Title,
                                         model.Price,
                                         model.Size,
                                         model.videoUrl,
                                         model.ThumbnailUrl,
                                         model.Description,
                                         model.ReleaseDate);

            TempData.AddSuccessMessage($"Game {model.Title} was created successful!");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        //GET: /Moderator/Game/Edit/{id}
        public async Task<ActionResult> Edit(int id)
        {
            var game =await this.games.FindByIdAsync(id);

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
                videoUrl = game.videoUrl
            });
        }

        //POST: /Moderator/Game/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ModeratorGameServiceModel model)
        {
            var game = await this.games.FindByIdAsync(id);

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            await this.games.EditGameAsync(id,
                                            model.Title,
                                            model.Price,
                                            model.Size,
                                            model.videoUrl,
                                            model.ThumbnailUrl,
                                            model.Description,
                                            model.ReleaseDate);

            TempData.AddSuccessMessage($"Game {model.Title} was created successful!");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        //GET: /Moderator/Game/Delete/{id}
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
                videoUrl = game.videoUrl
            });
        }

        //POST: /Moderator/Game/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Destroy(int id)
        {
            var game = await this.games.FindByIdAsync(id);

            if (game == null)
            {
                return this.HttpNotFound();
            }

            await this.games.DeleteAsync(id);

            TempData.AddErrorMessage($"Game {game.Title} was deleted successful!");

            return this.RedirectToAction(nameof(HomeController.Index),
                    "Home",
                    new { area = string.Empty });
        }
    }
}