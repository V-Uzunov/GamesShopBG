namespace GamesShopBG.Data.Migrations
{
    using GamesShopBG.Common;
    using GamesShopBG.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<GamesShopBGDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GamesShopBGDbContext context)
        {
            //this.userManager = new UserManager<User>(new UserStore<User>(context));
            //this.SeedRoles(context);
            //this.SeedUsers(context);
        }

        private void SeedRoles(GamesShopBGDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.ModeratorRole));
            context.SaveChanges();
        }

        private void SeedUsers(GamesShopBGDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            var adminName = GlobalConstants.AdminRole;
            var adminEmail = "admin@mysite.com";

            var adminUser =  this.userManager.FindByEmail(adminEmail);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    Email = adminEmail,
                    UserName = adminName,
                    Name = adminName,
                    Birthdate = DateTime.UtcNow
                };

                this.userManager.Create(adminUser, "admin12");

                this.userManager.AddToRole(adminUser.Id, adminName);
            }
            context.SaveChanges();
        }
    }
}
