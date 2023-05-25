using Data.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.Services.Implements;
using System.Drawing;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageServices _imageServices;
        private readonly IProductDetailServices _productDetailServices;
        public ImageController(IImageServices imageService, IProductDetailServices productDetailServices)
        {
            _imageServices = imageService;
            _productDetailServices = productDetailServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetImage()
        {
            return Ok(await _imageServices.GetAllImageAsync());
        }

        //[HttpPost]
        //public async Task<ActionResult> Create(Image image)
        //{
        //    if (await _imageServices.CheckMa(image.Ma))
        //    {
        //        return BadRequest("ma da ton tai");
        //    }
        //    else
        //    if (image != null)
        //    {
        //        if (await _imageServices.AddAsync(image))
        //        {
        //            return Ok("thanh cong");
        //        }
        //        else return NotFound("that bai");
        //    }
        //    else
        //    {
        //        return BadRequest("ko ton tai");
        //    }
        //}

        //[HttpPut("id")]
        //public async Task<ActionResult> Update(Image image, Guid id)
        //{
        //    if (image != null)
        //    {
        //        if (await _imageServices.UpdateAsync(image, id))
        //        {
        //            return Ok("thanh cong");
        //        }
        //        else return NotFound("that bai");
        //    }
        //    else return BadRequest("ko ton tai");
        //}

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(await _imageServices.DeleteAsync(id))
            {
                return Ok("thanh cong");
            }return NotFound("that bai");
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if(await _imageServices.GetByIdAsync(id)==null)
            {
                return NotFound("khong ton tai");
            }else return Ok(await _imageServices.GetByIdAsync(id));
        }
    }
}
