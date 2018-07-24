namespace GamesShopBG.Data.Common.Repositories
{
    using GamesShopBG.Data.Common.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Repository<T> : IRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        private DbContext context;
        private IDbSet<T> set;

        public Repository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.set;
        }

        public void Add(T entity)
        {
            this.set.Add(entity);
        }

        public T Find(object id)
        {
            var item = this.set.Find(id);

            if (item.IsDeleted)
            {
                return null;
            }

            return item;
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
        }

        public void Delete(object id)
        {
            T entity = this.Find(id);
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
        }

        public void HardDelete(T entity)
        {
            this.set.Remove(entity);
        }

        public void HardDelete(object id)
        {
            T entity = this.Find(id);
            this.set.Remove(entity);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}