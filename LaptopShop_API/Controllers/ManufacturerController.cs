using Data.Models;
using Data.Services.Implements;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerServices _manufacturerServices;
        public ManufacturerController()
        {
            _manufacturerServices = new ManufacturerServices();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllManufacturer() 
        {
           var listManufacturer = await _manufacturerServices.GetAllManufacturers();
            return Ok(listManufacturer);
        }
        [HttpPost]
        public async Task<ActionResult> CreateManufacturer(Manufacturer mf)
        {
            if (await _manufacturerServices.GetManufacturerByName(mf.Name))
            {
                return NotFound("Đã có tên");
            }
            else if (await _manufacturerServices.CreateManufacturer(mf))
            {
                return Ok("Thêm thành công");
            }
            else return NotFound("Thêm thất bại");
        }
        [HttpPut("id")]
        public async Task<ActionResult> UpdateManufacturer(Manufacturer mf, Guid id) 
        {
            if (await _manufacturerServices.UpdateManufacturer(mf, id))
            {
                return Ok("Sửa thành công");
            }
            else
            {
                return NotFound("Xóa thất bại");
            }
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteManufacturer(Guid id) 
        {
            if (await _manufacturerServices.DeleteManufacturer(id))
            {
                return Ok("Xóa thành công");
            }
            else return NotFound("Xóa thất bại");
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetManufacturerById(Guid id) 
        {
            if (await _manufacturerServices.GetManufacturerById(id) == null)
            {
                return NotFound("Không tìm thấy");
            }else return Ok(await _manufacturerServices.GetManufacturerById(id));
        }
    }
}   
