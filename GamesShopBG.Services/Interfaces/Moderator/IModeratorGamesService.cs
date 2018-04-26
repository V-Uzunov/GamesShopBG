namespace GamesShopBG.Services.Interfaces.Moderator
{
    using System;
    using System.Threading.Tasks;

    public interface IModeratorGamesService
    {
        Task CreateAsync(string title, decimal price, double size, string videoId, string thumbnailUrl, string description, DateTime releaseDate);
    }
}
