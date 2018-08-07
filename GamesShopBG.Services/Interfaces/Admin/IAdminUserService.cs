namespace GamesShopBG.Services.Interfaces.Admin
{
    using GamesShopBG.Services.Models.Admin;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Linq;

    public interface IAdminUserService
    {
        IEnumerable<AdminUserListingServiceModel> All();

        void Delete(string userId);

        IdentityRole GetRoles(string role);

        IQueryable<IdentityRole> GetAllRoles();

        IQueryable<AdminOrdersWithUserInfo> AllUsersWithOrders();

        AdminOrdersWithUserInfo FindOrderById(int id);

        void FinishOrder(int id);

        IQueryable<AdminOrdersWithUserInfo> ShowOrderPartialBy(string showedBy);
    }
}
