using Data.Models;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_Web.Controllers
{
    public class ColorController : Controller
    {

        CallAPIServices _callAPI = new CallAPIServices();
        //public IActionResult Index()
        //{
        //    IEnumerable<Color> _color = null;
        //    using(var client  = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44308/api/Color");
        //        var responseTask = client.GetAsync("Color");
        //        responseTask.Wait();

        //        var result=responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask=result.Content.ReadAsAsync<IList<Color>>();  
        //            readTask.Wait();
        //        }
        //    }
        //}

        //   [Authorize]
        public Task<IActionResult> Index()
        {
            IEnumerable<Color> _Color = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Color");
                var responseTask = client.GetAsync("Color");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Color>>();
                    readTask.Wait();
                    _Color = readTask.Result;
                    ViewBag.listColor = _Color;
                }
                else
                {
                    _Color = Enumerable.Empty<Color>();
                    ModelState.AddModelError(string.Empty, "error");
                }
                return Task.FromResult<IActionResult>(View(_Color));
            }
        }

        public async Task<IActionResult> Creates()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Creates(Color _ColorView)
        {
            Color _Color = new Color();
            _Color.Id = Guid.NewGuid();
            _Color.Ma = _ColorView.Ma;
            _Color.Name = _ColorView.Name;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Color");
                var postTask = client.PostAsJsonAsync<Color>("Color", _Color);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "that bai");
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> Updates(Guid id)
        {
            return View();
        }
        //[HttpPut("id")]


        public Task<IActionResult> Updates(Color _Color, Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44308/api/Color");

                var putTask = client.PutAsJsonAsync(client.BaseAddress, _Color);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
            }
            return Task.FromResult<IActionResult>(View(_Color));
        }

        public Task<IActionResult> Deletes(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44308/api/Color/id?Id={id}");
                var deleteTask = client.DeleteAsync(client.BaseAddress);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }

            }
            return Task.FromResult<IActionResult>(RedirectToAction("Index"));
        }
    }
}
