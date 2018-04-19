namespace GamesShopBG.Services.Implementations.Admin
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Data;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Services.Models.Admin;

    public class AdminUserService : IAdminUserService
    {
        private readonly GamesShopBGDbContext db;

        public AdminUserService(GamesShopBGDbContext db)
        {
            this.db = db;
        }

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
