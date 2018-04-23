namespace GamesShopBG.Services
{
    using GamesShopBG.Data;

    public abstract class Service
    {
        protected readonly GamesShopBGDbContext db;

        protected Service()
        {
            this.db = GamesShopBGDbContext.Create();
        }

        protected GamesShopBGDbContext DbContext { get; set; }
    }
}
