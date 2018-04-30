namespace GamesShopBG.Services.Implementations.Games
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Services.Models.Games;

    public class GameService : Service, IGameService
    {
        public async Task<IEnumerable<GameListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                             .Games
                             .OrderByDescending(g => g.Id)
                             .Where(g => g.Title.ToLower().Contains(searchText.ToLower()))
                             .ProjectTo<GameListingServiceModel>()
                             .ToListAsync();
        }

        public async Task<GamesDetailsServiceModel> FindByIdAsync(int id)
            => await this.db
                         .Games
                         .ProjectTo<GamesDetailsServiceModel>()
                         .Where(g => g.Id == id)
                         .FirstOrDefaultAsync();

        public IEnumerable<GameListingServiceModel> GetAllGames()
            => this.db
                   .Games
                   .ProjectTo<GameListingServiceModel>()
                   .ToList();
    }
}
