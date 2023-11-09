using CarShop.Models.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Session;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task SaveOrderAsync([FromBody] Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5247/Order");
            await _httpClient.SendAsync(request);
            RedirectToAction("OderShipped");
        }

        public IActionResult CeateOrder()
        {
          return RedirectToAction("SaveOrder");
        }
    }
}
