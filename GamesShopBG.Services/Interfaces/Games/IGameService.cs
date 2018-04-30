using System.Collections.Generic;
using System.Threading.Tasks;
using GamesShopBG.Services.Models.Games;

namespace GamesShopBG.Services.Interfaces.Games
{
    public interface IGameService
    {
        IEnumerable<GameListingServiceModel> GetAllGames();

        Task<IEnumerable<GameListingServiceModel>> FindAsync(string searchText);


        Task<GamesDetailsServiceModel> FindByIdAsync(int id);
    }
}
