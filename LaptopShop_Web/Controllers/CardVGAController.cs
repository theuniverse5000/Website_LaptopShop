using Data.Models;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Transactions;

namespace LaptopShop_Web.Controllers
{
    public class CardVGAController : Controller
    {
        CallAPIServices _callAPI = new CallAPIServices();

        public CardVGAController()
        {

        }
        public Task<IActionResult> Index()
        {
            IEnumerable<CardVGA> _cardVGA = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7158/api/");

                var responseTask = client.GetAsync("CardVGA");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CardVGA>>();
                    readTask.Wait();
                    _cardVGA
                        = readTask.Result;
                    ViewBag.listCardVGA = _cardVGA;
                }
                else
                {
                    _cardVGA = Enumerable.Empty<CardVGA>();
                    ModelState.AddModelError(string.Empty, "có lỗi xảy ra");
                }
                return Task.FromResult<IActionResult>(View(_cardVGA));
            }
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CardVGA _cardVGAView)
        {
            CardVGA _cardVGA = new CardVGA();
            _cardVGA.Id = Guid.NewGuid();
            _cardVGA.Ma = _cardVGAView.Ma;
            _cardVGA.Ten = _cardVGAView.Ten;
            _cardVGA.ThongSo = _cardVGAView.ThongSo;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7158/api/CardVGA");

                var postTask = client.PostAsJsonAsync<CardVGA>("CardVGA", _cardVGA);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Thêm Thất Bại!");
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var client = new HttpClient();
            string apiURL = $"https://localhost:7158/api/CardVGA{id}";

            var response = await client.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CardVGA>(apiData);
            return View(result);
        }
        
        public async Task<IActionResult> Update(CardVGA _cardVGA) 
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7158/api/CardVGA");

                var putTask = client.PutAsJsonAsync(client.BaseAddress, _cardVGA);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public Task<IActionResult> Delete(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7158/api/CardVGA/id?Id={id}");
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
