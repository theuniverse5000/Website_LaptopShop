using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Services.Implements;
using Data.Models;
using Data.Services.Interfaces;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCotroller : ControllerBase
    {
        private readonly IUserServices userServices;
        public UserCotroller()
        {
            userServices = new UserServices();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            var listUser = await userServices.GetAllUser();
            return Ok(listUser);

        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(User u)
        {
            var lstUser = await userServices.GetAllUser();

            if (u != null)
            {
                if (lstUser.Any(p => p.Username == u.Username))
                {
                    return BadRequest("UserName đã tồn tại");
                }
                else

                if (await userServices.Add(u))
                {
                    return Ok("Bạn thêm thành công");
                }
                return BadRequest("Không thành công !");
            }
            else
            {
                return BadRequest("Không tồn tại");
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(User u)
        {
            if (u != null)
            {
                if(await userServices.Update(u))
                {
                    return Ok("Bạn sửa thành công");
                }
                return BadRequest("Không thành công !");
            }
            else
            {
                return BadRequest("Không tồn tại");
            }
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteProductDetail(Guid id)
        {
            if (await userServices.Delete(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            else
            {
                return BadRequest("Thất bại");
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetProductDetailById(Guid id)
        {
            var productDetail = await userServices.GetById(id);
            return Ok(productDetail);
        }
    }
}
