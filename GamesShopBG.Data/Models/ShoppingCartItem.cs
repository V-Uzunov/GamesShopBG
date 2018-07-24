namespace GamesShopBG.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public string CartId { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Game Game { get; set; }
    }
}
