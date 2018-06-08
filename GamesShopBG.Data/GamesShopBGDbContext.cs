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
        
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        
        public static GamesShopBGDbContext Create()
        {
            return new GamesShopBGDbContext();
        }
    }
}
