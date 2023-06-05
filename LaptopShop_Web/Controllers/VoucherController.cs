using Data.Models;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace LaptopShop_Web.Controllers
{
    public class VoucherController : Controller
    {
        CallAPIServices _callAPI = new CallAPIServices();

        public VoucherController()
        {
                
        }
        public Task<IActionResult> Index()
        {
            IEnumerable<Voucher> _voucher = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7158/api/");

                var responseTask = client.GetAsync("Voucher");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Voucher>>();
                    readTask.Wait();
                    _voucher = readTask.Result;
                    ViewBag.listVoucher = _voucher;
                }
                else
                {
                    _voucher = Enumerable.Empty<Voucher>();
                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra");
                }
                return Task.FromResult<IActionResult>(View(_voucher));
            }
        }
        
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Voucher _voucher) 
        {
            Voucher _vc = new Voucher();
            _vc.ID = Guid.NewGuid();
            _vc.Ma = _voucher.Ma;
            _vc.Name = _voucher.Name;
            _vc.StartDay = _voucher.StartDay;
            _vc.EndDay = _voucher.EndDay;
            _vc.GiaTri = _voucher.GiaTri;
            _vc.SoLuong = _voucher.SoLuong;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7158/api/Voucher");

                var postTask = client.PostAsJsonAsync<Voucher>("Voucher", _vc);
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
        public async Task<IActionResult> Update() 
        {
            return View();
        }
        public Task<IActionResult> Update(Voucher _voucher) 
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:7158/api/Voucher");

                var putTask = client.PutAsJsonAsync<Voucher>("Voucher", _voucher);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Task.FromResult<IActionResult>(View(_voucher));
                }
                return Task.FromResult<IActionResult>(View(_voucher));
            }
        }
        public Task<IActionResult> Delete(Guid id)
        {
            using(var client = new HttpClient())
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
