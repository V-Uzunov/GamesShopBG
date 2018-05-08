namespace GamesShopBG.Services.Implementations.ShoppingCart
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Interfaces.ShoppingCart;
    using GamesShopBG.Services.Models.Games;
    using GamesShopBG.Services.Models.ShoppingCart;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ShoppingCart : Service, IShoppingCart
    {
        public const string CartSessionKey = "CartId";

        string ShoppingCartId { get; set; }
        
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(GamesCartServiceModel game)
        {
            // Get the matching cart and album instances
            var cartItem = this.db.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.GameId == game.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new ShoppingCartItem
                {
                    
                    GameId = game.Id,
                    CartId = ShoppingCartId,
                    Title = game.Title,
                    Amount = 1,
                    DateCreated = DateTime.Now
                };
                this.db.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Amount++;
            }
            // Save changes
            this.db.SaveChanges();
        }

        public GamesCartServiceModel GetGameFromCart(int id)
            => this.db
                   .ShoppingCartItems
                   .ProjectTo<GamesCartServiceModel>()
                   .FirstOrDefault(g => g.Id == id);

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = this.db.ShoppingCartItems.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.Id == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                    itemCount = cartItem.Amount;
                }
                else
                {
                    this.db.ShoppingCartItems.Remove(cartItem);
                }
                // Save changes
                this.db.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = this.db.ShoppingCartItems.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                this.db.ShoppingCartItems.Remove(cartItem);
            }
            // Save changes
            this.db.SaveChanges();
        }
        public List<ShoppingCartItemServiceModel> GetCartItems()
        {
            return this.db.ShoppingCartItems.ProjectTo<ShoppingCartItemServiceModel>().Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in this.db.ShoppingCartItems
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Amount).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in this.db.ShoppingCartItems
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Amount *
                              cartItems.Game.Price).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    GameId = item.GameId,
                    OrderId = order.Id,
                    Price = item.Game.Price,
                    Amount = item.Amount
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Amount * item.Game.Price);

                this.db.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.OrderTotal = orderTotal;

            // Save the order
            this.db.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.Id;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = this.db.ShoppingCartItems.Where(
                c => c.CartId == ShoppingCartId);

            foreach (var item in shoppingCart)
            {
                item.CartId = userName;
            }
            this.db.SaveChanges();
        }
    }
}
