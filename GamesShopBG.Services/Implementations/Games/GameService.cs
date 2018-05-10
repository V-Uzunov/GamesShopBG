namespace GamesShopBG.Services.Implementations.Games
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Common;
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Services.Models.Games;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<IEnumerable<GameListingServiceModel>> GetAllGamesAsync(int page = 1)
            => await this.db
                   .Games
                   .OrderByDescending(a => a.Id)
                   .Skip((page - 1) * GlobalConstants.GamePagesSize)
                   .Take(GlobalConstants.GamePagesSize)
                   .ProjectTo<GameListingServiceModel>()
                   .ToListAsync();

        public GamesCartServiceModel GetGame(int gameId)
            => this.db
                   .Games
                   .ProjectTo<GamesCartServiceModel>()
                   .FirstOrDefault(g => g.Id == gameId);

        public async Task<int> GetTotalAsync()
            => await this.db
                   .Games
                   .CountAsync();
    }
}
