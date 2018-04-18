namespace GamesShopBG.Data
{
    using GamesShopBG.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class GamesShopBGDbContext : IdentityDbContext<User>
    {
        public GamesShopBGDbContext()
            : base("GamesShopBGDb", throwIfV1Schema: false)
        {

        }

        public static GamesShopBGDbContext Create()
        {
            return new GamesShopBGDbContext();
        }
    }
}