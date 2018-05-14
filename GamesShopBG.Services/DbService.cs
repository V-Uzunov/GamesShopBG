namespace GamesShopBG.Services
{
    using GamesShopBG.Data;

    public abstract class DbService
    {
        protected readonly GamesShopBGDbContext db;

        protected DbService()
        {
            this.db = GamesShopBGDbContext.Create();
        }

        protected GamesShopBGDbContext DbContext { get; set; }
    }
}
