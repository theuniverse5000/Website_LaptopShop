using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace LaptopShop_Web.Controllers
{
    public class UserController : Controller
    {
        HttpClient httpClient;
        public UserController()
        {
            httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllUsers()
        {
            string ApiURL = "https://localhost:44308/api/User";
            var response = await httpClient.GetAsync(ApiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var use = JsonConvert.DeserializeObject<List<User>>(apiData);
            return View(use);
        }

        public async Task<IActionResult> AddUsers()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUsers(User u)
        {

            string apiURL = "https://localhost:44308/api/User/add-use";
            var content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllUsers");
            }


            return View("GetAllUsers");

        }
        public async Task<IActionResult> DetailsUse(Guid Id)
        {
            string apiURL = $"https://localhost:44308/api/User/id?id={Id}";
            var response = await httpClient.GetAsync(apiURL);
            string apidata = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(apidata);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> EditsUse(Guid Id)
        {
            string apiURL = $"https://localhost:44308/api/User/id?id={Id}";
            var response = await httpClient.GetAsync(apiURL);
            string apidata = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(apidata);

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditsUse(Guid Id, User u)
        {
            string apiURL = $"https://localhost:44308/api/User/update-use?id={Id}";
            var content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllUsers");
            }
            return View(u);
        }

        public async Task<IActionResult> DeletesUse(Guid Id)
        {
            string apiURL = $"https://localhost:44308/api/User/id?id={Id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllUsers");
            }
            return RedirectToAction("GetAllUsers");
        }

    }
}
