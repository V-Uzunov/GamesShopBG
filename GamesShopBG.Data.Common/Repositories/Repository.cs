namespace GamesShopBG.Data.Common.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext context;
        private IDbSet<T> set;

        public Repository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public virtual void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public virtual T Find(object id)
        {
            return this.set.Find(id);
        }

        public virtual void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        internal virtual  void ChangeState(T entity, EntityState state)
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
