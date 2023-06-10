using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LaptopShop_Web.Controllers
{
    public class RamController : Controller
    {
        public RamController()
        {
            
        }
        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiUrl = "https://localhost:44308/api/Ram";
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Ram>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ram ram)
        {
            if(!ModelState.IsValid)
                return View(ram);
            var httpClient = new HttpClient();
            string apiUrl = "https://localhost:44308/api/Ram";
            var json = JsonConvert.SerializeObject(ram);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("","Thêm thất bại");

            return View(ram);
        }
        [HttpPut]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:44308/api/Ram{id}";
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Ram>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Edit(Ram ram)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Ram");
                // http post
                var putTask = client.PutAsJsonAsync(client.BaseAddress, ram);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowAll");
                }
            }
            return View();
        }
        public async Task<IActionResult> Delete(Guid id) 
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:44308/api/Ram/id?Id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Xóa thất bại");
            return BadRequest();
        }

    }
}
