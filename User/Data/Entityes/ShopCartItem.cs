namespace User.Data.Entityes
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public int Prise { get; set; }
        public string? ProductName { get; set; }
        public string? ShopCartId { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
