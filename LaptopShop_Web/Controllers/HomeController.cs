using Data.Models;
using Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LaptopShop_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient(); // tạo 1 http client để call api
            var reponseProductDetail = await httpClient.GetAsync("https://localhost:44308/api/ProductDetail");
            string apiDataProductDetail = await reponseProductDetail.Content.ReadAsStringAsync();
            ViewBag.listProductDetailIndex = JsonConvert.DeserializeObject<List<ProductDetailView>>(apiDataProductDetail);
            // Get Image
            var reponseImage = await httpClient.GetAsync("https://localhost:44308/api/Image");
            string apiDataImage = await reponseImage.Content.ReadAsStringAsync();
            ViewBag.listImageIndex = JsonConvert.DeserializeObject<List<Image>>(apiDataImage);
            var listProductDetail = JsonConvert.DeserializeObject<List<ProductDetailView>>(apiDataProductDetail);
            return View(listProductDetail);
        }
        public async Task<IActionResult> ShowChiTietSanPham(Guid id)
        {
            var httpClient = new HttpClient(); // tạo 1 http client để call api
            var reponseProductDetail = await httpClient.GetAsync($"https://localhost:44308/api/ProductDetail/id?id={id}");
            string apiDataProductDetail = await reponseProductDetail.Content.ReadAsStringAsync();
            //   ViewBag.ProductDetailIndex = JsonConvert.DeserializeObject<ProductDetailView>(apiDataProductDetail);
            var ProductDetail = JsonConvert.DeserializeObject<ProductDetailView>(apiDataProductDetail);
            return View(ProductDetail);
        }
        public async Task<IActionResult> ShowListProduct()
        {
            var httpClient = new HttpClient(); // tạo 1 http client để call api
            var reponseProductDetail = await httpClient.GetAsync("https://localhost:44308/api/ProductDetail");
            string apiDataProductDetail = await reponseProductDetail.Content.ReadAsStringAsync();
            ViewBag.listProductDetailIndex = JsonConvert.DeserializeObject<List<ProductDetailView>>(apiDataProductDetail);
            // Get Image
            var reponseImage = await httpClient.GetAsync("https://localhost:44308/api/Image");
            string apiDataImage = await reponseImage.Content.ReadAsStringAsync();
            ViewBag.listImageIndex = JsonConvert.DeserializeObject<List<Image>>(apiDataImage);
            var listProductDetail = JsonConvert.DeserializeObject<List<ProductDetailView>>(apiDataProductDetail);
            return View(listProductDetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        //   [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}