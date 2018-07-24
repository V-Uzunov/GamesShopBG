namespace GamesShopBG.Data
{
    using GamesShopBG.Data.Models;
    using GamesShopBG.Data.Repositories;
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

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }
        
        public IRepository<IdentityRole> Roles
        {
            get
            {
                return this.GetRepository<IdentityRole>();
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
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


        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>) this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
