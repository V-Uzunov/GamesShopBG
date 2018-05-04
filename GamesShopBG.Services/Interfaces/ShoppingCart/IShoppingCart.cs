namespace GamesShopBG.Services.Interfaces.ShoppingCart
{
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Models.Games;
    using GamesShopBG.Services.Models.ShoppingCart;
    using System.Collections.Generic;
    using System.Web;

    public interface IShoppingCart
    {
        void AddToCart(GamesCartServiceModel game);

        GamesCartServiceModel GetGameFromCart(int id);
        int CreateOrder(Order order);
        string GetCartId(HttpContextBase context);
        void MigrateCart(string userName);
        int RemoveFromCart(int id);
        void EmptyCart();
        List<ShoppingCartItemServiceModel> GetCartItems();

        int GetCount();
        decimal GetTotal();
    }
}
