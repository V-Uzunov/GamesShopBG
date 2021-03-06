﻿namespace GamesShopBG.Services.Implementations.ShoppingCart
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Data;
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Interfaces.ShoppingCart;
    using GamesShopBG.Services.Models.Games;
    using GamesShopBG.Services.Models.Order;
    using GamesShopBG.Services.Models.ShoppingCart;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ShoppingCartService :  IShoppingCartService
    {
        private readonly GamesShopBGDbContext data;

        public ShoppingCartService()
            : this(new GamesShopBGDbContext())
        {

        }

        public ShoppingCartService(GamesShopBGDbContext data)
        {
            this.data = data;
        }

        public const string CartSessionKey = "CartId";

        string ShoppingCartId { get; set; }

        public static ShoppingCartService GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCartService();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCartService GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(GamesCartServiceModel game)
        {
            // Get the matching cart and album instances
            var cartItem = this.data.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == this.ShoppingCartId
                && c.GameId == game.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new ShoppingCartItem
                {

                    GameId = game.Id,
                    CartId = this.ShoppingCartId,
                    Title = game.Title,
                    Amount = 1,
                    DateCreated = DateTime.Now
                };
                this.data.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Amount++;
            }
            // Save changes
            this.data.SaveChanges();
        }

        public GamesCartServiceModel GetGameFromCart(int id)
            => this.data
                   .ShoppingCartItems
                   .ProjectTo<GamesCartServiceModel>()
                   .FirstOrDefault(g => g.Id == id);

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = this.data.ShoppingCartItems.Single(
                cart => cart.CartId == this.ShoppingCartId
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
                    this.data.ShoppingCartItems.Remove(cartItem);
                }
                // Save changes
                this.data.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = this.data.ShoppingCartItems.Where(
                cart => cart.CartId == this.ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                this.data.ShoppingCartItems.Remove(cartItem);
            }
            // Save changes
            this.data.SaveChanges();
        }
        public IQueryable<ShoppingCartItemServiceModel> GetCartItems()
        {
            return this.data.ShoppingCartItems.ProjectTo<ShoppingCartItemServiceModel>().Where(
                cart => cart.CartId == this.ShoppingCartId);
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = this.data
                .ShoppingCartItems
                .Where(c => c.CartId == this.ShoppingCartId)
                .Select(c => (int?)c.Amount)
                .Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply game price by count of that game to get 
            // the current price for each of those game in the cart
            // sum all game price totals to get the cart total
            decimal? total = this.data
                .ShoppingCartItems
                .Where(c => c.CartId == this.ShoppingCartId)
                .Select(c => (int?)c.Amount * c.Game.Price)
                .Sum();
            return total ?? decimal.Zero;
        }
        public void CreateOrder(OrderServiceModelForShoppingCart order)
        {
            decimal orderTotal = 0;

            var cartItems = this.GetCartItems();
            var orderData = new Order
            {
                Id = order.Id,
                City = order.City,
                AddressLine = order.AddressLine,
                Email = order.Email,
                FirstName = order.FirstName,
                LastName = order.LastName,
                PhoneNumber = order.PhoneNumber,
                ZipCode = order.ZipCode,
                OrderDate = DateTime.UtcNow
            };
            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    GameId = item.GameId,
                    OrderId = orderData.Id,
                    Price = item.Game.Price,
                    Amount = item.Amount,
                    GameTitle = item.GameTitle
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Amount * item.Game.Price);
                orderData.OrderDetails.Add(orderDetail);
                this.data.OrderDetails.Add(orderDetail);
            }

            // Set the order's total to the orderTotal count
            orderData.OrderTotal = orderTotal;

            // Save the order
            this.data.Orders.Add(orderData);

            // Empty the shopping cart
            this.EmptyCart();
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
            var shoppingCart = this.data.ShoppingCartItems.Where(
                c => c.CartId == this.ShoppingCartId);

            foreach (var item in shoppingCart)
            {
                item.CartId = userName;
            }
            this.data.SaveChanges();
        }
    }
}