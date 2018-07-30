namespace GamesShopBG.Services.Models.Games
{
    using GamesShopBG.Common;
    using System;
    using System.Collections.Generic;

    public class HomeIndexGamesListingsViewModel
    {
        public IEnumerable<GameListingServiceModel> Games { get; set; }

        public int TotalGames { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalGames / GlobalConstants.GamePagesSize);

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int CurrentPage { get; set; }

        public int NextPage
            => this.CurrentPage == this.TotalPages
                ? this.TotalPages
                : this.CurrentPage + 1;
    }
}