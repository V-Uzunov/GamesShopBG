using AutoMapper;
using GamesShopBG.Data.Models;
using GamesShopBG.Services.Models.Admin;
using GamesShopBG.Services.Models.Moderator;

namespace GamesShopBG.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void ConfigureAutomapper()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<AdminUserListingServiceModel, User>();
                action.CreateMap<ModeratorGameServiceModel, Game>();
            });
        }
    }
}