namespace GamesShopBG.Services.Implementations.Moderator
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Interfaces.Moderator;
    using GamesShopBG.Services.Models.Moderator;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class ModeratorGamesService : DbService, IModeratorGamesService
    {
        public async Task CreateAsync(string title,
            decimal price,
            double size,
            string videoUrl,
            string thumbnailUrl,
            string description,
            DateTime releaseDate)
        {
            var game = new Game
            {
                Title = title,
                Price = price,
                Size = size,
                VideoUrl = videoUrl,
                ThumbnailUrl = thumbnailUrl,
                Description = description,
                ReleaseDate = releaseDate
            };

            this.db.Games.Add(game);
            await this.db.SaveChangesAsync();
        }

        public async Task EditGameAsync(int id,
            string title,
            decimal price,
            double size,
            string videoUrl,
            string thumbnailUrl,
            string description,
            DateTime releaseDate)
        {
            var gameExist = await this.db.Games.FindAsync(id);

            if (gameExist == null)
            {
                return;
            }
            gameExist.Title = title;
            gameExist.Price = price;
            gameExist.Size = size;
            gameExist.VideoUrl = videoUrl;
            gameExist.ThumbnailUrl = thumbnailUrl;
            gameExist.Description = description;
            gameExist.ReleaseDate = releaseDate;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gameId = await this.db.Games.FindAsync(id);

            if (gameId == null)
            {
                return;
            }

            this.db.Games.Remove(gameId);
            await this.db.SaveChangesAsync();
        }

        public async Task<ModeratorGameServiceModel> FindByIdAsync(int id)
            => await this.db
                    .Games
                    .Where(g => g.Id == id)
                    .ProjectTo<ModeratorGameServiceModel>()
                    .FirstOrDefaultAsync();
    }
}
