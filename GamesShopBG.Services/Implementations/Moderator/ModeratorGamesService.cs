namespace GamesShopBG.Services.Implementations.Moderator
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Data;
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Interfaces.Moderator;
    using GamesShopBG.Services.Models.Moderator;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class ModeratorGamesService : IModeratorGamesService
    {
        private readonly IGamesShopBGData data;

        public ModeratorGamesService(IGamesShopBGData data)
        {
            this.data = data;
        }

        public void Create(ModeratorGameServiceModel model)
        {
            var game = new Game
            {
                Title = model.Title,
                Price = model.Price,
                Size = model.Size,
                VideoUrl = model.VideoUrl,
                ThumbnailUrl = model.ThumbnailUrl,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate
            };

            this.data.Games.Add(game);
            this.data.Games.SaveChanges();
        }

        public void EditGame(ModeratorGameServiceModel model)
        {
            var gameExist = this.data.Games.Find(model.Id);

            if (gameExist == null)
            {
                return;
            }

            gameExist.Title = model.Title;
            gameExist.Price = model.Price;
            gameExist.Size = model.Size;
            gameExist.VideoUrl = model.VideoUrl;
            gameExist.ThumbnailUrl = model.ThumbnailUrl;
            gameExist.Description = model.Description;
            gameExist.ReleaseDate = model.ReleaseDate;
            
            this.data.Games.SaveChanges();
        }

        public void Delete(int id)
        {
            var gameId = this.data.Games.Find(id);

            if (gameId == null)
            {
                return;
            }

            this.data.Games.Delete(gameId);
            this.data.Games.SaveChanges();
        }

        public async Task<ModeratorGameServiceModel> FindByIdAsync(int id)
            => await this.data
                    .Games
                    .All()
                    .Where(g => g.Id == id)
                    .ProjectTo<ModeratorGameServiceModel>()
                    .FirstOrDefaultAsync();
    }
}
