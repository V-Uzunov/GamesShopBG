namespace GamesShopBG.Services.Implementations.Admin
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Data;
    using GamesShopBG.Services.Interfaces.Admin;
    using GamesShopBG.Services.Models.Admin;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminUserService :  IAdminUserService
    {
        private readonly IGamesShopBGData data;

        public AdminUserService(IGamesShopBGData data)
        {
            this.data = data;
        }

        public IEnumerable<AdminUserListingServiceModel> All()
            => this.data
               .Users
               .All()
               .ProjectTo<AdminUserListingServiceModel>();
        
        public void Delete(string userId)
        {
            var findUser = this.data.Users.Find(userId);

            if (findUser == null)
            {
                return;
            }

            this.data.Users.Delete(findUser);

            this.data.Users.SaveChanges();
        }

        public IEnumerable<IdentityRole> GetAllRoles()
            => this.data
                .Roles
                .All();

        public IdentityRole GetRoles(string role)
            => this.data
                .Roles
                .Find(role);
    }
}
