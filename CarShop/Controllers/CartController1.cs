using CarShop.Models.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Session;
using System;
using Newtonsoft.Json;

namespace CarShop.Controllers
{
    public class CartController : Controller
    {
        private HttpClient _httpClient;
        public CartController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        /*private static ShopCart GetCart(IServiceProvider service)
        {
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart();
        }*/

        public ViewResult MyCart()
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart()
            });
        }

        public IActionResult AddToCart(int id)
        {
            var response = _httpClient.GetAsync($"http://localhost:5193/Product/{id}").Result;
            response.EnsureSuccessStatusCode();
            var product = response.Content.ReadAsAsync<Product>().Result;
            if (product != null)
            {
                var cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }

            return RedirectToAction("Catalog", "Caars");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var response = _httpClient.GetAsync($"http://localhost:5193/Product/{id}").Result;
            response.EnsureSuccessStatusCode();
            var product = response.Content.ReadAsAsync<Product>().Result;
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("Catalog");
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

        private Cart SaveCart(Cart cart)
        {
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            return cart;
        }
    }
}