namespace GamesShopBG.Services.Implementations.ShoppingCart
{
    using AutoMapper.QueryableExtensions;
    using GamesShopBG.Data;
    using GamesShopBG.Data.Models;
    using GamesShopBG.Services.Models.Games;
    using GamesShopBG.Services.Models.ShoppingCart;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ShoppingCart : Service
    {
        public int ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        //public static ShoppingCart GetCart(IServiceProvider services)
        //{
        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?
        //        .HttpContext.Session;

        //    var context = services.GetService<AppDbContext>();
        //    string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        //    session.SetString("CartId", cartId);

        //    return new ShoppingCart(context) { ShoppingCartId = cartId };
        //}
        
        public void AddToCart(GamesCartServiceModel game, int amount)
        {
            var shoppingCartItem =
                    this.db.ShoppingCartItems.SingleOrDefault(
                        s => s.Game.Id == game.Id && s.ShoppingCartId == ShoppingCartId);
            var dataGame = this.db.Games.FirstOrDefault(g => g.Id == game.Id);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Game = dataGame,
                    Amount = 1
                };

                this.db.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            this.db.SaveChanges();
        }

        public int RemoveFromCart(GamesCartServiceModel game)
        {
            var shoppingCartItem =
                    this.db.ShoppingCartItems.SingleOrDefault(
                        s => s.Game.Id == game.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    this.db.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            this.db.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       this.db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Game)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = this.db
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            this.db.ShoppingCartItems.RemoveRange(cartItems);

            this.db.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = this.db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Game.Price * c.Amount).Sum();
            return total;
        }
    }
}
