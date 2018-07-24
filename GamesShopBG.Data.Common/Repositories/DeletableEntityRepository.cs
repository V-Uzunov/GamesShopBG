namespace GamesShopBG.Data.Common.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using GamesShopBG.Data.Common.Models;

    public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity, new()
    {
        private IDbSet<T> set;

        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
            this.set = context.Set<T>();
        }

        public override IQueryable<T> All()
        {
            return this.set.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.set;
        }

        public override void Add(T entity)
        {
            this.set.Add(entity);
        }

        public override T Find(object id)
        {
            var item = this.set.Find(id);

            if (item.IsDeleted)
            {
                return null;
            }

            return item;
        }

        public override T Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            return entity;
        }

        public override T Delete(object id)
        {
            T entity = this.Find(id);
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            return entity;
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
    }
}
