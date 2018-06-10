namespace GamesShopBG.Services.Implementations.Games
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Common;
    using GamesShopBG.Data;
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Services.Models.Games;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class GameService : IGameService
    {
        private readonly IGamesShopBGData data;

        public GameService(IGamesShopBGData data)
        {
            this.data = data;
        }

        public IQueryable<GameListingServiceModel> Find(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return this.data
                             .Games
                             .All()
                             .OrderByDescending(g => g.Id)
                             .Where(g => g.Title.ToLower().Contains(searchText.ToLower()))
                             .ProjectTo<GameListingServiceModel>();
        }

        public async Task<GamesDetailsServiceModel> FindByIdAsync(int id)
            => await this.data
                         .Games
                         .All()
                         .ProjectTo<GamesDetailsServiceModel>()
                         .Where(g => g.Id == id)
                         .FirstOrDefaultAsync();

        public IQueryable<GameListingServiceModel> GetAllGames(int page = 1)
            =>  this.data
                   .Games
                   .All()
                   .OrderByDescending(a => a.Id)
                   .Skip((page - 1) * GlobalConstants.GamePagesSize)
                   .Take(GlobalConstants.GamePagesSize)
                   .ProjectTo<GameListingServiceModel>();

        public GamesCartServiceModel GetGame(int gameId)
            => this.data
                   .Games
                   .All()
                   .ProjectTo<GamesCartServiceModel>()
                   .FirstOrDefault(g=> g.Id == gameId);

        public async Task<int> GetTotalAsync()
            => await this.data
                   .Games
                   .All()
                   .CountAsync();
    }
}
