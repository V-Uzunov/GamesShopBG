namespace GamesShopBG.Data.Common.Repositories
{
    using System.Linq;

    public interface IDeletableEntityRepository<T> : IRepository<T>
        where T : class
    {
        IQueryable<T> AllWithDeleted();

        void Delete(T entity);

        void Delete(object id);

        void HardDelete(T entity);

        void HardDelete(object id);
    }
}
