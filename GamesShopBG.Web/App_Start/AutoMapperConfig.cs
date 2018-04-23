using AutoMapper;
using GamesShopBG.Data.Models;
using GamesShopBG.Services.Models.Admin;

namespace GamesShopBG.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void ConfigureAutomapper()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<AdminUserListingServiceModel, User>();
            });
        }
    }
}