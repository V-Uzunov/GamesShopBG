namespace GamesShopBG.Services.Interfaces.Admin
{
    using GamesShopBG.Services.Models.Admin;
    using System.Collections.Generic;

    public interface IAdminUserService
    {
        IEnumerable<AdminUserListingServiceModel> All();

        void Delete(string userId);
    }
}
