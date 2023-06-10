using Data.Models;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_Web.Controllers
{
    public class RoleController : Controller
    {
        CallAPIServices _callAPI = new CallAPIServices();


        public Task<IActionResult> Index()
        {
            IEnumerable<Role> _role = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Role");
                var responseTask = client.GetAsync("Role");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Role>>();
                    readTask.Wait();
                    _role = readTask.Result;
                    ViewBag.listRole = _role;
                }
                else
                {
                    _role = Enumerable.Empty<Role>();
                    ModelState.AddModelError(string.Empty, "error");
                }
                return Task.FromResult<IActionResult>(View(_role));
            }
        }

        public async Task<IActionResult> Creates()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Creates(Role _roleView)
        {
            Role _role = new Role();
            _role.Id = Guid.NewGuid();
            _role.RoleName = _roleView.RoleName;
            _role.Status = _roleView.Status;
            _role.Description = _roleView.Description;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Role");
                var postTask = client.PostAsJsonAsync<Role>("Role", _role);
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


        public Task<IActionResult> Updates(Role _role, Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44308/api/Role");

                var putTask = client.PutAsJsonAsync(client.BaseAddress, _role);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Task.FromResult<IActionResult>(RedirectToAction("Index"));
                }
            }
            return Task.FromResult<IActionResult>(View(_role));
        }

        public Task<IActionResult> Deletes(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44308/api/Role/id?Id={id}");
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
