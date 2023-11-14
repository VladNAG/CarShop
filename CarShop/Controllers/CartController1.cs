using CarShop.Models.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Session;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace CarShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private HttpClient _httpClient;
        public CartController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

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

            return RedirectToAction("MyCart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var response = _httpClient.GetAsync($"http://localhost:5193/Product/{id}").Result;
            response.EnsureSuccessStatusCode();
            var product = response.Content.ReadAsAsync<Product>().Result;
            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }

            return RedirectToAction("MyCart");
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