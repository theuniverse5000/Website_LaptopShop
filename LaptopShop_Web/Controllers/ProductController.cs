using Data.Models;
using Data.Models.ViewModels;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text;

namespace LaptopShop_Web.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {
        }
        public async Task<IActionResult> ShowAll()
        {
            var httpClient = new HttpClient();
            string apiURL = "https://localhost:44308/api/Product";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(apiData);
            return View(result);
<<<<<<< Updated upstream
            //IEnumerable<ProductView> product = null;

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:44308/api/");
            //    //HTTP GET
            //    var responseTask = client.GetAsync("Product");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IList<ProductView>>();
            //        readTask.Wait();

            //        product = readTask.Result;
            //        ViewBag.listProduct = product;
            //    }
            //    else //web api sent error response 
            //    {
            //        //log response status here..
            //        product = Enumerable.Empty<ProductView>();

            //        ModelState.AddModelError(string.Empty, "Có lỗi xảy ra");
            //    }
            //    return Task.FromResult<IActionResult>(View(product));
=======
            
>>>>>>> Stashed changes
        
        }
        public async Task<IActionResult> Create()
        {
            //var httpClient = new HttpClient(); // tạo 1 http client để call api
            //var responseManufacturer = await httpClient.GetAsync("https://localhost:44308/api/Manufacturer");

            //string apiDataManufacturer = await responseManufacturer.Content.ReadAsStringAsync();
            //ViewBag.listManufacturer = JsonConvert.DeserializeObject<List<Cpu>>(apiDataManufacturer);
            //listManufacturers = JsonConvert.DeserializeObject<List<Manufacturer>>(apiDataManufacturer);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
        if (!ModelState.IsValid)
            return View(product);

        var httpClient = new HttpClient();

        string apiURL = "https://localhost:44308/api/Product";

        var json = JsonConvert.SerializeObject(product);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(apiURL, content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("ShowAll");
        }
        ModelState.AddModelError("", "Thêm thất bại");

        return View(product);
        //Product product = new Product();
        //product.Id = Guid.NewGuid();
        //product.Name = productView.Name;
        //product.IDManufacturer = listManufacturers.FirstOrDefault(x => x.Name == productView.NameManufacturer).Id;
        //using (var client = new HttpClient())
        //{
        //    client.BaseAddress = new Uri("https://localhost:44308/api/Product");

        //    //HTTP POST
        //    var postTask = client.PostAsJsonAsync<Product>("Product", product);
        //    postTask.Wait();

        //    var result = postTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("ShowAll");
        //    }
        //}
        //ModelState.AddModelError(string.Empty, "Thêm thất bại !!!");

        //return View();
    }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:44308/api/Produt{id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Product>(apiData);
            return View(result);
            //return View();
        }

        public async Task<IActionResult> Edit(Product product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Product");

                //HTTP POST
                var putTask = client.PutAsJsonAsync(client.BaseAddress, product);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("ShowAll");

                }
            }
            return View();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:44308/api/Product");

            //    //HTTP POST
            //    var putTask = client.PutAsJsonAsync<Product>("Product", product);
            //    putTask.Wait();

            //    var result = putTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {

            //        return Task.FromResult<IActionResult>(RedirectToAction("ShowAll"));
            //    }
            //}
            //return Task.FromResult<IActionResult>(View(product));
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:44308/api/Product/id?Id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            ModelState.AddModelError("", "Xóa thất bại");
            return BadRequest();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri($"https://localhost:44308/api/Product/id?Id={id}");

            //    //HTTP DELETE
            //    var deleteTask = client.DeleteAsync(client.BaseAddress);
            //    deleteTask.Wait();

            //    var result = deleteTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return Task.FromResult<IActionResult>(RedirectToAction("ShowAll"));
            //    }
            //}
            //return Task.FromResult<IActionResult>(RedirectToAction("ShowAll"));
        }
    }
}
