using AutoMapper;
using GamesShopBG.Data.Models;
using GamesShopBG.Services.Models.Admin;
using GamesShopBG.Services.Models.Games;
using GamesShopBG.Services.Models.Moderator;
using GamesShopBG.Services.Models.Order;
using GamesShopBG.Services.Models.ShoppingCart;

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
                action.CreateMap<GameListingServiceModel, Game>();
                action.CreateMap<GamesDetailsServiceModel, Game>();
                action.CreateMap<GamesCartServiceModel, Game>();

                action.CreateMap<ShoppingCartItemServiceModel, ShoppingCartItem>();

                action.CreateMap<OrderServiceModelForShoppingCart, Order>();
                action.CreateMap<AdminOrderDetailsServiceModel, OrderDetail>();
                action.CreateMap<AdminOrdersWithUserInfo, Order>();
            });
        }
    }
}