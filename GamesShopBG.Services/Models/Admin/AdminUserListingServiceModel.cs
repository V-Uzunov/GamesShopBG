namespace GamesShopBG.Services.Models.Admin
{
    using GamesShopBG.Common.Mapping;
    using GamesShopBG.Data.Models;

    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
