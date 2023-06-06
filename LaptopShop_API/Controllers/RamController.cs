using Data.Models;
using Data.Services.Implements;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly IRamServices _ramServices;
        //  ApplicationDbContext _dbContext;
        public RamController()
        {
            _ramServices = new RamServices();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllRam()
        {
            return Ok(await _ramServices.GetAllRams());
        }
        [HttpPost]
        public async Task<ActionResult> CreateRam(Ram ram) 
        {
            if (await _ramServices.GetRamByMa(ram.Ma))
            {
                return NotFound("Đã có mã");
            }
            else if (await _ramServices.CreateRam(ram))
            {
                return Ok("Thêm thành công");
            }
            else return NotFound("Thêm thất bại");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRam(Ram ram)
        {
            if (await _ramServices.UpdateRam(ram, ram.Id))
            {
                return Ok("Sửa thành công");
            }
            else return NotFound("Sửa thất bại");
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteRam(Guid id)
        {
            if (await _ramServices.DeleteRam(id))
            {
                return Ok("Xóa thành công");
            }
            else return NotFound("Xóa thất bại");
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetRamById(Guid id)
        {
            if (await _ramServices.GetRamById(id) == null)
            {
                return NotFound("Không tìm thấy");
            }
            else return Ok(await _ramServices.GetRamById(id));
        }
    }
}
