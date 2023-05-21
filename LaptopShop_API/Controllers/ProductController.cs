using Data.Models;
using Data.Services.Implements;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(await _productServices.GetAllProducts());
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product obj)
        {
            if (await _productServices.GetProductByName(obj.Name))
            {
                return NotFound("Đã có tên");
            }
            if (await _productServices.CreateProduct(obj))
            {
                return Ok("Thêm thành công");
            }
            else return NotFound("Thêm thất bại");
        }

        [HttpPut("id")]
        public async Task<ActionResult> UpdateProduct(Product obj, Guid id) 
        {
            if (await _productServices.UpdateProduct(obj, id))
            {
                return Ok("Sửa thành công");
            }
            else return NotFound("Sửa thất bại");
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteProduct( Guid id)
        {
            if (await _productServices.DeleteProduct(id))
            {
                return Ok("Xóa thành công");
            }
            return NotFound("Xóa thất bại");
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if (await _productServices.GetProductById(id) == null)
            {
                return NotFound("Không tìm thấy");
            }
            else return Ok(await _productServices.GetProductById(id));
        }
        
    }
}
