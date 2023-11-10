using CarShop.Models.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Session;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Text.Json.Nodes;

namespace CarShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private HttpClient _httpClient;
        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> MyOrdersAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5247/Order");
            response.EnsureSuccessStatusCode();
            var order = await response.Content.ReadAsAsync<List<Order>>();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrderAsync(Order order)
        {
            if (ModelState.IsValid)
            {
                var cart = GetCart();
                order.IdProducts = cart.Lines.Select(x=>x.Product.Id).ToList();
                order.Created = DateTime.Now;
                var jsonObject = JsonConvert.SerializeObject(order);
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("http://localhost:5247/Order", content);
                var contents = await response.Content.ReadAsStringAsync();
                return View("SaveOrder");
            }
            else
            {
                return View("NotSaveOrder");
            }
        }

        private Cart GetCart()
        {
            var cartstring = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartstring))
            {
                return new Cart();
            }

            var cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("Cart"));
            return cart;
        }
    }
}
