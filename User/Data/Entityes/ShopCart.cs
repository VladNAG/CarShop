namespace User.Data.Entityes
{
    public class ShopCart
    {
        public string? ShopCartId { get; set; }

        public List<ShopCartItem>? listShopItems { get; set; }
    }
}
