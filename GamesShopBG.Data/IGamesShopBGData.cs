namespace GamesShopBG.Data
{
    using GamesShopBG.Data.Models;
    using GamesShopBG.Data.Repositories;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IGamesShopBGData
    {
        IRepository<User> Users
        {
            get;
        }

        IRepository<IdentityRole> Roles
        {
            get;
        }

        IRepository<Game> Games
        {
            get;
        }

        IRepository<Order> Orders
        {
            get;
        }

        IRepository<OrderDetail> OrderDetails
        {
            get;
        }

        IRepository<ShoppingCartItem> ShoppingCartItems
        {
            get;
        }
    }
}
