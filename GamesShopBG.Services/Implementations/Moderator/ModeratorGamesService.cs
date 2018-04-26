namespace GamesShopBG.Services.Implementations.Moderator
{
    using System;
    using System.Threading.Tasks;
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Interfaces.Moderator;

    public class ModeratorGamesService : Service, IModeratorGamesService
    {
        public async Task CreateAsync(string title,
            decimal price,
            double size,
            string videoId,
            string thumbnailUrl,
            string description,
            DateTime releaseDate)
        {
            var game = new Game
            {
                Title = title,
                Price = price,
                VideoId = videoId,
                ThumbnailUrl = thumbnailUrl,
                Description = description,
                ReleaseDate = releaseDate
            };

            this.db.Games.Add(game);
            await this.db.SaveChangesAsync();
        }
    }
}
