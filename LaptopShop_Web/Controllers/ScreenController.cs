using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LaptopShop_Web.Controllers
{
    public class ScreenController : Controller
    {
        HttpClient httpClient;
        public ScreenController()
        {
            httpClient = new HttpClient();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllScreens()
        {
            string ApiURL = "https://localhost:44308/api/Screen";
            var response = await httpClient.GetAsync(ApiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var screen = JsonConvert.DeserializeObject<List<Screen>>(apiData);
            return View(screen);
        }
        public async Task<IActionResult> AddSc()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSc(Screen s)
        {

            string apiURL = "https://localhost:44308/api/Screen/add-screen";
            var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllScreens");
            }


            return View("GetAllScreens");

        }
        public async Task<IActionResult> Details(Guid Id)
        {
            string apiURL = $"https://localhost:44308/api/Screen/id?id={Id}";
            var response = await httpClient.GetAsync(apiURL);
            string apidata = await response.Content.ReadAsStringAsync();
            var screen = JsonConvert.DeserializeObject<Screen>(apidata);
            return View(screen);
        }
        [HttpGet]
        public async Task<IActionResult> Edits(Guid Id)
        {
            string apiURL = $"https://localhost:44308/api/Screen/id?id={Id}";
            var response = await httpClient.GetAsync(apiURL);
            string apidata = await response.Content.ReadAsStringAsync();
            var screen = JsonConvert.DeserializeObject<Screen>(apidata);
    
            return View(screen);
        }
        [HttpPost]
        public async Task<IActionResult> Edits(Guid Id, Screen screen)
        {
            string apiURL = $"https://localhost:44308/api/Screen/update-screen?id={Id}";
            var content = new StringContent(JsonConvert.SerializeObject(screen), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllScreens");
            }
            return View(screen);
        }

        public async Task<IActionResult> Deletes(Guid Id)
        {
            string apiURL = $"https://localhost:44308/api/Screen/{Id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllScreens");
            }
            return RedirectToAction("GetAllScreens");
        }
    }
}
