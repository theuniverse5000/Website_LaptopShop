using Data.Models;
using Data.Models.ViewModels;
using LaptopShop_Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_Web.Controllers
{
    public class CartController : Controller
    {
        CallAPIServices callAPI = new CallAPIServices();
        static Guid getUserId;

        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username == null)
            {
                return RedirectToAction("CheckLogin", "Login");
            }
            HttpClient client = new HttpClient();
            var listUser = await client.GetFromJsonAsync<List<User>>("https://localhost:44308/api/User");

            getUserId = listUser.FirstOrDefault(x => x.Username == username).Id;

            //   Guid getUserId = Guid.Parse("574a4e76-9dde-4f22-b89f-90a987765d72");
            //   ViewBag.GetCartForUser = _cartDetailServices.GetCartDetailJoinProductDetail().Where(a => a.UserId == getUserId);
            var listCartDetail = await callAPI.GetAll<CartDetailView>("https://localhost:44308/api/CartDetail");
            var itemInCart = listCartDetail.Where(x => x.UserId == getUserId).ToList();
            ViewBag.itemsInCart = itemInCart;
            return View(itemInCart);
        }
        public async Task<IActionResult> AddCart(Guid id)
        {

            var listCart = await callAPI.GetAll<Cart>("https://localhost:44308/api/Cart");
            var cartNgan = listCart.FirstOrDefault(x => x.UserId == getUserId);
            if (cartNgan == null)
            {
                using (var client = new HttpClient())
                {
                    Cart t = new Cart();
                    t.UserId = getUserId;
                    t.Description = "Chất lượng bình thường";

                    client.BaseAddress = new Uri("https://localhost:44308/api/Cart");
                    var postTask = client.PostAsJsonAsync<Cart>("Cart", t);
                    postTask.Wait();
                }
            }
            using (var client = new HttpClient())
            {
                CartDetail x = new CartDetail();
                x.Id = new Guid();
                x.IdProductDetails = id;
                x.UserId = getUserId;
                x.Quantity = 1;
                client.BaseAddress = new Uri("https://localhost:44308/api/CartDetail");
                var postTask = client.PostAsJsonAsync<CartDetail>("CartDetail", x);
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
        public async Task<IActionResult> CongOneQuantity(Guid id)
        {

            var listCartDetail = await callAPI.GetAll<CartDetail>($"https://localhost:44308/api/CartDetail/GetCartDetailNoJoin");

            var x = listCartDetail.FirstOrDefault(x => x.Id == id);
            x.Quantity += 1;
            using (var client = new HttpClient())
            {
                //
                client.BaseAddress = new Uri("https://localhost:44308/api/CartDetail/UpdateQuantity");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<CartDetail>(client.BaseAddress, x);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    TempData["ThongBaoHanhDong"] = "Số lượng sản phẩm vừa tăng";
                    return RedirectToAction("Index", "Cart");
                }
            }
            return RedirectToAction("Index", "Cart");
        }
        public async Task<IActionResult> TruOneQuantity(Guid id)
        {
            //  Guid getUserId = Guid.Parse("F9605C6D-FBA8-4220-BFAA-F2C629008745");
            var listCartDetail = await callAPI.GetAll<CartDetail>($"https://localhost:44308/api/CartDetail/GetCartDetailNoJoin");
            //   var itemInCart = listCartDetail.Where(x => x.UserId == getUserId).ToList();
            var x = listCartDetail.FirstOrDefault(x => x.Id == id);
            if (x.Quantity <= 1)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"https://localhost:44308/api/CartDetail/id?Id={id}");

                    //HTTP DELETE
                    var deleteTask = client.DeleteAsync(client.BaseAddress);
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["ThongBaoHanhDong"] = "Bạn vừa xóa sản phẩm khỏi giỏ hàng";
                        return RedirectToAction("Index", "Cart");
                    }
                }
            }
            else
            {
                x.Quantity -= 1;
                using (var client = new HttpClient())
                {
                    //
                    client.BaseAddress = new Uri("https://localhost:44308/api/CartDetail/UpdateQuantity");

                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<CartDetail>(client.BaseAddress, x);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        TempData["ThongBaoHanhDong"] = "Số lượng sản phẩm vừa giảm";
                        return RedirectToAction("Index", "Cart");
                    }
                }
            }
            return RedirectToAction("Index", "Cart");
        }
        public async Task<IActionResult> DeleteItemInCart(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://localhost:44308/api/CartDetail/id?Id={id}");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["ThongBaoHanhDong"] = "Bạn vừa xóa sản phẩm khỏi giỏ hàng";
                    return RedirectToAction("Index", "Cart");
                }
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
