namespace GamesShopBG.Services.Interfaces.ShoppingCart
{
    using GamesShopBG.Services.Models.Games;
    using GamesShopBG.Services.Models.Order;
    using GamesShopBG.Services.Models.ShoppingCart;
    using System.Linq;
    using System.Web;

    public interface IShoppingCartService
    {
        void AddToCart(GamesCartServiceModel game);

        GamesCartServiceModel GetGameFromCart(int id);
        void CreateOrder(OrderServiceModelForShoppingCart order);
        string GetCartId(HttpContextBase context);
        void MigrateCart(string userName);
        int RemoveFromCart(int id);
        void EmptyCart();
        IQueryable<ShoppingCartItemServiceModel> GetCartItems();

        int GetCount();
        decimal GetTotal();
    }
}
