using Data.Models;
using Data.Models.ViewModels;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_Web.Controllers
{
    public class ProductDetailController : Controller
    {
        CallAPIServices callAPI = new CallAPIServices();
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDetailView> productDetails = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ProductDetail");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProductDetailView>>();
                    readTask.Wait();

                    productDetails = readTask.Result;
                    ViewBag.listProductDetail = productDetails;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    productDetails = Enumerable.Empty<ProductDetailView>();

                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra");
                }
                return View(productDetails);
            }

            //  return View(await callAPI.GetAll<ProductDetailView>("https://localhost:44346/api/ProductDetail"));
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ProductDetail productDetail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/ProductDetail");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<ProductDetail>("ProductDetail", productDetail);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Thêm thất bại !!!");

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            ProductDetail productDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44346/api/ProductDetail/id?Id={id}");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProductDetail>();
                    readTask.Wait();

                    productDetail = readTask.Result;
                }
            }
            return View(productDetail);
            //   return View();
        }
        // [HttpPut]
        public async Task<IActionResult> Update(ProductDetail productDetail)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44346/api/ProductDetail");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<ProductDetail>("ProductDetail", productDetail);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(productDetail);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44346/api/ProductDetail/id?Id={id}");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

    }
}
