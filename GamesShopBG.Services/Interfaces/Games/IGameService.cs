namespace GamesShopBG.Services.Interfaces.Games
{
    using GamesShopBG.Services.Models.Games;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGameService
    {
        IEnumerable<GameListingServiceModel> GetAllGames();

        Task<IEnumerable<GameListingServiceModel>> FindAsync(string searchText);
        
        Task<GamesDetailsServiceModel> FindByIdAsync(int id);
    }
}
