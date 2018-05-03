namespace GamesShopBG.Services.Models.ShoppingCart
{
    using GamesShopBG.Services.Models.Games;

    public class ShoppingCartItemServiceModel
    {
        public int Id { get; set; }
        public GamesCartServiceModel Game { get; set; }
        public int Amount { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
