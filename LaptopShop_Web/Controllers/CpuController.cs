using Data.Models;
using Data.Models.ViewModels;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LaptopShop_Web.Controllers
{
    public class CpuController : Controller
    {
        public CpuController()
        {

        }

        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:7158/api/Cpu";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Cpu>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cpu cpu)
        {
            if (!ModelState.IsValid)
                return View(cpu);

            var httpClient = new HttpClient();

            string apiURL = "https://localhost:7158/api/Cpu";

            var json = JsonConvert.SerializeObject(cpu);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Thêm thất bại");

            return View(cpu);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7158/api/Cpu{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Cpu>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(Cpu cpu)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7158/api/Cpu");

                //HTTP POST
                var putTask = client.PutAsJsonAsync(client.BaseAddress, cpu);
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
            string apiURL = $"https://localhost:7158/api/Cpu/id?Id={id}";

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
