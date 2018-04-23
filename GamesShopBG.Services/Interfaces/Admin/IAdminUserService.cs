﻿namespace GamesShopBG.Services.Interfaces.Admin
{
    using GamesShopBG.Services.Models.Admin;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity;

    public interface IAdminUserService
    {
        IEnumerable<AdminUserListingServiceModel> All();

        void Delete(string userId);

        IdentityRole GetRoles(string role);

        IEnumerable<IdentityRole> GetAllRoles();
    }
}