namespace GamesShopBG.Data.GamesShopBGData
{
    using GamesShopBG.Data.Common.Models;
    using GamesShopBG.Data.Common.Repositories;
    using GamesShopBG.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class GamesShopBGData : IGamesShopBGData
    {
        private readonly DbContext context;
        private Dictionary<Type, object> repositories;

        public GamesShopBGData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IDeletableEntityRepository<User> Users
        {
            get
            {
                return this.GetDeletableEntityRepository<User>();
            }
        }
        
        public IRepository<IdentityRole> Roles
        {
            get
            {
                return this.GetRepository<IdentityRole>();
            }
        }

        public IDeletableEntityRepository<Game> Games
        {
            get
            {
                return this.GetDeletableEntityRepository<Game>();
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
            }
        }

        public IRepository<OrderDetail> OrderDetails
        {
            get
            {
                return this.GetRepository<OrderDetail>();
            }
        }

        public IRepository<ShoppingCartItem> ShoppingCartItems
        {
            get
            {
                return this.GetRepository<ShoppingCartItem>();
            }
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>()
            where T : class, IDeletableEntity, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
