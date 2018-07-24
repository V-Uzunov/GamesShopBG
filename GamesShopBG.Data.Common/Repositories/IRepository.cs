namespace GamesShopBG.Data.Common.Repositories
{
    using GamesShopBG.Data.Common.Models;
    using System.Linq;

    public interface IRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        void Add(T entity);

        T Find(object id);

        void Delete(T entity);

        void Delete(object id);

        void HardDelete(T entity);

        void HardDelete(object id);

        int SaveChanges();
    }
}