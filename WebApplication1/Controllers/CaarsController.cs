﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models.Entityes;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    public class CaarsController : Controller
        {
            private HttpClient _httpClient;
            public CaarsController(IHttpClientFactory httpClientFactory)
            {
                _httpClient = httpClientFactory.CreateClient();
            }
            [HttpGet]
            [Route("AllCars")]
            public async Task<IActionResult> AllCarsAsync()
            {
            var response = await _httpClient.GetAsync("http://localhost:5193/Product");
            response.EnsureSuccessStatusCode();
            var model = await response.Content.ReadAsAsync<List<Product>>();
            return View(model);
        }

        /*[HttpPost]
        [Route("Caars/Test")]
        public IActionResult GreateTest(CarViewModel ca)
        {
            if (ModelState.IsValid)
            {
                _iCarSevises.Create(ca);
                List<CarViewModel> model = _iCarSevises.GetAll();

                return View("~/Views/Caars/Test.cshtml", model);
            }
            string errorMessages = "";
            // проходим по всем элементам в ModelState
            foreach (var item in ModelState)
            {
                // если для определенного элемента имеются ошибки
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    errorMessages = $"{errorMessages}\nОшибки для свойства {item.Key}:\n";
                    // пробегаемся по всем ошибкам
                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages = $"{errorMessages}{error.ErrorMessage}\n";
                    }
                }
            }
            return View(errorMessages);
        }

        [HttpPost]
        [Route("DeleteTest")]
        [CustomExceptionFilter]
        public IActionResult DeleteTest(int id)
        {
            if (id == 1 || id == 2)
                throw new Exception();
            _iCarSevises.Delete(id);
            return RedirectToAction("Test");
        }


        [HttpGet]
        [Route("Info")]
        public IActionResult Info(int id)
        {

            var model = _iCarSevises.Get(id);
            return View(model);
        }

        [HttpPost]
        [Route("UpdateTest")]
        public IActionResult UpdateTest(CarViewModel ca)
        {

            _iCarSevises.Update(ca);
            List<CarViewModel> model = _iCarSevises.GetAll();
            return View("~/Views/Caars/Test.cshtml", model);
        }
*/
    }
}
