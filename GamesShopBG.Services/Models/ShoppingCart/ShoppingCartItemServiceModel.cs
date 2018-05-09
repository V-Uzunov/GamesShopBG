namespace GamesShopBG.Services.Models.ShoppingCart
{
    using GamesShopBG.Services.Models.Games;
    using System;

    public class ShoppingCartItemServiceModel
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public int Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public GamesCartServiceModel Game { get; set; }
    }
}
