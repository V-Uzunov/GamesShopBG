namespace GamesShopBG.Data.Common.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext context;
        private IDbSet<T> set;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return this.set;
        }

        public virtual void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public virtual T Find(object id)
        {
            return this.set.Find(id);
        }

        public virtual void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        public virtual T Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public virtual T Delete(object id)
        {
            T entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;

        }
    }
}
