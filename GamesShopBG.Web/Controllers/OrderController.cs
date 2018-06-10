namespace GamesShopBG.Web.Controllers
{
    using GamesShopBG.Services.Implementations.ShoppingCart;
    using GamesShopBG.Services.Interfaces.ShoppingCart;
    using GamesShopBG.Services.Models.Order;
    using GamesShopBG.Web.Infrastructure.Extensions;
    using System.Linq;
    using System.Web.Mvc;
    
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IShoppingCartService shoppingCart;

        public OrderController(IShoppingCartService shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        //GET: /Order/Checkout/
        public ActionResult Checkout()
        {
            var cart = ShoppingCartService.GetCart(this.HttpContext);
            if (cart.GetCartItems().Count() == 0)
            {
                TempData.AddErrorMessage("Your cart is empty, add some games first");

                return this.RedirectToAction(
                nameof(ShoppingCartController.Index),
                "ShoppingCart",
                new { area = string.Empty });
            }
            return View();
        }

        //POST: /Order/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(OrderServiceModelForShoppingCart model)
        {
            var cart = ShoppingCartService.GetCart(this.HttpContext);
            if (cart.GetCartItems().Count() == 0)
            {
                TempData.AddErrorMessage("Your cart is empty, add some products first");

                return this.RedirectToAction(
                nameof(ShoppingCartController.Index),
                "ShoppingCart",
                new { area = string.Empty });
            }

            if (!ModelState.IsValid)
            {
                return this.View();
            }

            cart.CreateOrder(model);

            TempData.AddSuccessMessage($"Order was created successful!");

            return this.RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }
    }
}