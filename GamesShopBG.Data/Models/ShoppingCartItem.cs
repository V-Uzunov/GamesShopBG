namespace GamesShopBG.Data.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public int Amount { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
