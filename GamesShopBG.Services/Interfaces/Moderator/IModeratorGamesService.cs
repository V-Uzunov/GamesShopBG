namespace GamesShopBG.Services.Interfaces.Moderator
{
    using GamesShopBG.Services.Models.Moderator;
    using System;
    using System.Threading.Tasks;

    public interface IModeratorGamesService
    {
        void Create(ModeratorGameServiceModel model);

        Task<ModeratorGameServiceModel> FindByIdAsync(int id);

        void EditGame(ModeratorGameServiceModel model);

        void Delete(int id);
    }
}
