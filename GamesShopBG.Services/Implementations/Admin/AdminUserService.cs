namespace GamesShopBG.Services.Implementations.Admin
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Services.Models.Admin;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminUserService : Service, IAdminUserService
    {

        public IEnumerable<AdminUserListingServiceModel> All()
            => this.db
            .Users
            .ProjectTo<AdminUserListingServiceModel>()
            .ToList();

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
    }
}
