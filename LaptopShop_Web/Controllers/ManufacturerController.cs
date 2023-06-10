using Data.Models;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaptopShop_Web.Controllers
{
    public class ManufacturerController : Controller
    {
        CallAPIServices _callAPI = new CallAPIServices();

        public ManufacturerController()
        {
               
        }
        public Task<IActionResult> Index()
        {
            IEnumerable<Manufacturer> _manufacturer = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/");

                var responseTask = client.GetAsync("Manufacturer");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Manufacturer>>();
                    _manufacturer = readTask.Result;
                    ViewBag.Manufacturer = _manufacturer;
                }
                else
                {
                    _manufacturer = Enumerable.Empty<Manufacturer>();
                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra");
                }
                return Task.FromResult<IActionResult>(View(_manufacturer));
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Manufacturer _manufacturer) 
        {
            Manufacturer _mf = new Manufacturer();
            _mf.Id = Guid.NewGuid();
            _mf.Name = _manufacturer.Name;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Manufacturer");

                var postTask = client.PostAsJsonAsync<Manufacturer>("Manufacturer", _mf);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
           var client = new HttpClient();
            string apiURL = $"https://localhost:44308/api/Manufacturer{id}";

            var response = await client.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Manufacturer>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Update(Manufacturer _manufacturer)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44308/api/Manufacturer");
                var putTask = client.PutAsJsonAsync<Manufacturer>("Manufacturer", _manufacturer);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
        public Task<IActionResult> Delete(Guid id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44308/api/Manufacturer/id?Id={id}");
                var deleteTask = client.DeleteAsync(client.BaseAddress);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
                return Task.FromResult<IActionResult>(RedirectToAction("Index"));
            }
        }
    }
}
