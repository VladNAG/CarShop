using Microsoft.Extensions.DependencyInjection;

namespace CarShop.Models.Entityes
{
    public class CartIndexViewModel
    {
        public Cart? Cart { get; set; }
        public Order? Order { get; set; }
    }
}
