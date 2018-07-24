namespace GamesShopBG.Data
{
    using GamesShopBG.Data.Common.Repositories;
    using GamesShopBG.Data.Models;

    public interface IGamesShopBGData
    {
        IRepository<User> Users
        {
            get;
        }

        IRepository<Role> Roles
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

        IRepository<ShoppingCartItem> ShoppingCartItems
        {
            get;
        }
    }
}
