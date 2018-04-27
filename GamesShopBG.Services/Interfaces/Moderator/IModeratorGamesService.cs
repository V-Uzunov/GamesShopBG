namespace GamesShopBG.Services.Interfaces.Moderator
{
    using GamesShopBG.Services.Models.Moderator;
    using System;
    using System.Threading.Tasks;

    public interface IModeratorGamesService
    {
        Task CreateAsync(string title, decimal price, double size, string videoUrl, string thumbnailUrl, string description, DateTime releaseDate);

        Task<ModeratorGameServiceModel> FindByIdAsync(int id);

        Task EditGameAsync(int id, string title, decimal price, double size, string videoUrl, string thumbnailUrl, string description, DateTime releaseDate);

        Task DeleteAsync(int id);
    }
}
