using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace LaptopShop_Web.Controllers
{
    public class HardDriveController : Controller
    {
        HttpClient httpClient;
        public HardDriveController()
        {
            httpClient = new HttpClient();
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetHDs()
        {
            string ApiURL = "https://localhost:44308/api/HardDrive";
            var response = await httpClient.GetAsync(ApiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var hd = JsonConvert.DeserializeObject<List<HardDrive>>(apiData);
            return View(hd);
        }
        public async Task<IActionResult> AddHD()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddHD(HardDrive h)
        {

            string apiURL = "https://localhost:44308/api/HardDrive/add-harddrive";
            var content = new StringContent(JsonConvert.SerializeObject(h), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetHDs");
            }


            return View("GetHDs");

        }
        //public async Task<IActionResult> Details(Guid Id)
        //{
        //    string apiURL = $"https://localhost:44308/api/HardDrive/id?id={Id}";
        //    var response = await httpClient.GetAsync(apiURL);
        //    string apidata = await response.Content.ReadAsStringAsync();
        //    var hd = JsonConvert.DeserializeObject<HardDrive>(apidata);
        //    return View(hd);
        //}
        [HttpGet]
        public async Task<IActionResult> Edits(Guid Id)
        {
            string apiURL = $"https://localhost:44308/api/HardDrive/id?id={Id}";
            var response = await httpClient.GetAsync(apiURL);
            string apidata = await response.Content.ReadAsStringAsync();
            var hd = JsonConvert.DeserializeObject<HardDrive>(apidata);

            return View(hd);
        }
        [HttpPost]
        public async Task<IActionResult> Edits(Guid Id, HardDrive h)
        {
            string apiURL = $"https://localhost:44308/api/HardDrive/update-harddrive?id={Id}";
            var content = new StringContent(JsonConvert.SerializeObject(h), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetHDs");
            }
            return View(h);
        }

        public async Task<IActionResult> Deletes(Guid Id)
        {
            string apiURL = $"https://localhost:44308/api/HardDrive/{Id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetHDs");
            }
            return RedirectToAction("GetHDs");
        }

    }
}
