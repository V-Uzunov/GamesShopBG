namespace GamesShopBG.Web.ViewModels.Home
{
    using GamesShopBG.Services.Models.Games;
    using System.Collections.Generic;

    public class HomeIndexViewModel
    {
        public IEnumerable<GameListingServiceModel> Games { get; set; }

        public string SearchText { get; set; }
    }
}