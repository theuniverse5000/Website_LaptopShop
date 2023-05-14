using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Ram> rams = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Ram");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Ram>>();
                    readTask.Wait();

                    rams = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    rams = Enumerable.Empty<Ram>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            ViewBag.ListRam = rams;
            return View(rams);
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