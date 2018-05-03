namespace GamesShopBG.Web.Controllers
{
    using GamesShopBG.Services.Implementations.ShoppingCart;
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Services.Models.ShoppingCart;
    using System.Web.Mvc;

    public class ShoppingCartController : Controller
    {
        private readonly IGameService games;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(IGameService games,
                                      ShoppingCart shoppingCart)
        {
            this.games = games;
            this.shoppingCart = shoppingCart;
        }

        public ActionResult Index()
        {
            var items = this.shoppingCart.GetShoppingCartItems();
            this.shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartServiceModel
            {
                ShoppingCart = this.shoppingCart,
                ShoppingCartTotal = this.shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public ActionResult AddToShoppingCart(int id)
        {
            var selectedGame = this.games.GetGame(id);

            if (selectedGame != null)
            {
                this.shoppingCart.AddToCart(selectedGame, 1);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromShoppingCart(int id)
        {
            var selectedGame = this.games.GetGame(id);

            if (selectedGame != null)
            {
                this.shoppingCart.RemoveFromCart(selectedGame);
            }
            return RedirectToAction("Index");
        }
    }
}