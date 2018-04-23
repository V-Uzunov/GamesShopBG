namespace GamesShopBG.Services.Implementations.Admin
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Services.Models.Admin;
<<<<<<< HEAD
    using Microsoft.AspNet.Identity.EntityFramework;
=======
>>>>>>> 7ddd3470b491433b80f2f7c7338892e6de3fa740
    using System.Collections.Generic;
    using System.Linq;

    public class AdminUserService : Service, IAdminUserService
    {
<<<<<<< HEAD
        
=======

>>>>>>> 7ddd3470b491433b80f2f7c7338892e6de3fa740
        public IEnumerable<AdminUserListingServiceModel> All()
            => this.db
            .Users
            .ProjectTo<AdminUserListingServiceModel>()
            .ToList();
<<<<<<< HEAD
        
=======

>>>>>>> 7ddd3470b491433b80f2f7c7338892e6de3fa740
        public void Delete(string userId)
        {
            var findUser = this.db.Users.Find(userId);

            if (findUser == null)
            {
                return;
            }

            this.db.Users.Remove(findUser);

            this.db.SaveChanges();
        }

        public IEnumerable<IdentityRole> GetAllRoles()
            => this.db
                .Roles;

        public IdentityRole GetRoles(string role)
            => this.db
                .Roles
                .Find(role);
    }
}
