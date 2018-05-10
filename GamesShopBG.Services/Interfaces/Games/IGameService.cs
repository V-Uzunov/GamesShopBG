namespace GamesShopBG.Services.Interfaces.Games
{
    using GamesShopBG.Services.Models.Games;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGameService
    {
        Task<IEnumerable<GameListingServiceModel>> GetAllGamesAsync(int page = 1);

        Task<IEnumerable<GameListingServiceModel>> FindAsync(string searchText);
        
        Task<GamesDetailsServiceModel> FindByIdAsync(int id);

        GamesCartServiceModel GetGame(int gameId);

        Task<int> GetTotalAsync();
    }
}
