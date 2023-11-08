namespace User.Data.Entityes
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public int Prise { get; set; }
        public Product product { get; set; }
        public string? ShopCartId { get; set; }
    }
}
