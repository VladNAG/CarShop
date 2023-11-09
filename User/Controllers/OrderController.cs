using Microsoft.AspNetCore.Mvc;
using User.Data.Entityes;
using User.Interfeces;

namespace User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IServise _orderService;

        public OrderController(IServise orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public Order[] GetAllOrders()
        {
            return _orderService.GetAll();
        }

        [HttpPost]
        public void CreateNewOrder([FromBody] Order order)
        {
            _orderService.Save(order);
        }
    }
}