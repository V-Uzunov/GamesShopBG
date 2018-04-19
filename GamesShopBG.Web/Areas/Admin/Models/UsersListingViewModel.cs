namespace GamesShopBG.Web.Areas.Admin.Models
{
    using GamesShopBG.Services.Models.Admin;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class UsersListingViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}