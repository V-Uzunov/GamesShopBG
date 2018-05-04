namespace GamesShopBG.Services.Models.ShoppingCart
{
    using GamesShopBG.Services.Implementations.ShoppingCart;
    using System.Collections.Generic;

    public class ShoppingCartServiceModel
    {
        public List<ShoppingCartItemServiceModel> ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
