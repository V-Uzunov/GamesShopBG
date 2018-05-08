namespace GamesShopBG.Web.Controllers
{
    using GamesShopBG.Services.Implementations.ShoppingCart;
    using GamesShopBG.Services.Interfaces.Games;
    using GamesShopBG.Services.Interfaces.ShoppingCart;
    using GamesShopBG.Services.Models.ShoppingCart;
    using System.Web.Mvc;

    public class ShoppingCartController : Controller
    {
        private readonly IGameService games;
        private readonly IShoppingCartService shoppingCart;


        public ShoppingCartController(IGameService games,
                                      IShoppingCartService shoppingCart)
        {
            this.games = games;
            this.shoppingCart = shoppingCart;
        }

        public ActionResult Index()
        {
            var cart = ShoppingCartService.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartServiceModel
            {
                 ShoppingCart = cart.GetCartItems(),
                 ShoppingCartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the game from the database
            var addedGame = this.games.GetGame(id);
            // Add it to the shopping cart
            var cart = ShoppingCartService.GetCart(this.HttpContext);

            cart.AddToCart(addedGame);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCartService.GetCart(this.HttpContext);

            // Get the name of the game to display confirmation
            var gameName = this.shoppingCart.GetGameFromCart(id).Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveServiceModel
            {
                Message = Server.HtmlEncode(gameName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCartService.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}