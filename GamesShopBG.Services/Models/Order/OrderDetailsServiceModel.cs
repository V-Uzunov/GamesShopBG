namespace GamesShopBG.Services.Models.Order
{
    using System;

    public class OrderDetailsServiceModel
    {
        public string CartId { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public int Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
