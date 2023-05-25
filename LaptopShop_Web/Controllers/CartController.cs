using Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_Web.Controllers
{
    public class CartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CartDetailView cartDetailView)
        {
            return View();
        }
    }
}
