namespace GamesShopBG.Services.Interfaces.Games
{
    using GamesShopBG.Services.Models.Games;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IGameService
    {
        IQueryable<GameListingServiceModel> GetAllGames(int page = 1);

        IQueryable<GameListingServiceModel> Find(string searchText);
        
        Task<GamesDetailsServiceModel> FindByIdAsync(int id);

        GamesCartServiceModel GetGame(int gameId);

        Task<int> GetTotalAsync();
    }
}
