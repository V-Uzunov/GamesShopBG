namespace GamesShopBG.Data.Models
{
    using System;

    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string CartId { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Game Game { get; set; }
    }
}
