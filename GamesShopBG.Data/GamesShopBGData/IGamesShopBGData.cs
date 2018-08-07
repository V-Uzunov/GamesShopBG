namespace GamesShopBG.Data.GamesShopBGData
{
    using GamesShopBG.Data.Common.Repositories;
    using GamesShopBG.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IGamesShopBGData
    {
        IDeletableEntityRepository<User> Users
        {
            get;
        }

        IRepository<IdentityRole> Roles
        {
            get;
        }

        IDeletableEntityRepository<Game> Games
        {
            get;
        }

        IDeletableEntityRepository<Order> Orders
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
