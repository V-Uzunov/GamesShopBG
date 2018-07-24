﻿namespace GamesShopBG.Data.Common.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        T Find(object id);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        int SaveChanges();
    }
}