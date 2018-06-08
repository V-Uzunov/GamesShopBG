namespace GamesShopBG.Data
{
    using GamesShopBG.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class GamesShopBGDbContext : IdentityDbContext<User>
    {
        public GamesShopBGDbContext()
            : base("GamesShopBGDbConnection")
        {

        }
        
        public virtual IDbSet<Game> Games { get; set; }
        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<OrderDetail> OrderDetails { get; set; }
        public virtual IDbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        
        public static GamesShopBGDbContext Create()
        {
            return new GamesShopBGDbContext();
        }
    }
}
