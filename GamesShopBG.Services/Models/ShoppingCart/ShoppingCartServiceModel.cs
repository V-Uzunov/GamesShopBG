namespace GamesShopBG.Services.Models.ShoppingCart
{
    using GamesShopBG.Services.Implementations.ShoppingCart;

    public class ShoppingCartServiceModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
