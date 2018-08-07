namespace GamesShopBG.Services.Implementations.Admin
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Data.GamesShopBGData;
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

        public IQueryable<AdminOrdersWithUserInfo> AllUsersWithOrders()
            => this.data
               .Orders
               .AllWithDeleted()
               .OrderBy(x=> x.OrderDate)
               .ProjectTo<AdminOrdersWithUserInfo>();

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

        public AdminOrdersWithUserInfo FindOrderById(int id)
            => this.data
                .Orders
                .All()
                .Where(x=> x.Id == id)
                .ProjectTo<AdminOrdersWithUserInfo>()
                .FirstOrDefault();

        public void FinishOrder(int id)
        {
            var orderById = this.data.Orders.Find(id);

            if (orderById == null)
            {
                return;
            }

            this.data.Orders.Delete(orderById);
            this.data.Orders.SaveChanges();
        }

        public IQueryable<IdentityRole> GetAllRoles()
            => this.data
                .Roles
                .All();

        public IdentityRole GetRoles(string role)
            => this.data
                .Roles
                .Find(role);

        public IQueryable<AdminOrdersWithUserInfo> ShowOrderPartialBy(string showedBy)
        {
            if (showedBy == "progress")
            {
                return this.data
                        .Orders
                        .All()
                        .ProjectTo<AdminOrdersWithUserInfo>();
            }
            else if (showedBy == "finished")
            {
                return this.data
                    .Orders
                    .AllWithDeleted()
                    .Where(x => x.IsDeleted)
                    .ProjectTo<AdminOrdersWithUserInfo>();
            }
            return this.data
                    .Orders
                    .AllWithDeleted()
                    .ProjectTo<AdminOrdersWithUserInfo>();
        }
    }
}
