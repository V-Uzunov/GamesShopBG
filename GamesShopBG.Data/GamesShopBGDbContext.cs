namespace GamesShopBG.Data
{
    using GamesShopBG.Data.Common.Models;
    using GamesShopBG.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GamesShopBGDbContext : IdentityDbContext<User>
    {
        public GamesShopBGDbContext()
            : base("GamesShopBGDbConnection")
        {

        }
        
        public virtual IDbSet<Game> Games { get; set; }
        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<OrderDetail> OrderDetails { get; set; }
        public virtual IDbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        
        public static GamesShopBGDbContext Create()
        {
            return new GamesShopBGDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}