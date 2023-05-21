using Data.Models;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        private readonly ICpuServices _cpuServices;
        public CpuController(ICpuServices cpuServices)
        {
            _cpuServices = cpuServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCpu()
        {
            return Ok(await _cpuServices.GetAllCpus());
        }
        [HttpPost]
        public async Task<ActionResult> CreateCpu(Cpu obj)
        {
            if (await _cpuServices.CreateCpu(obj))
            {
                return Ok("Thêm thành công");
            }
            else return NotFound("Thêm thất bại");
        }
        [HttpPut("id")]
        public async Task<ActionResult> UpdateCpu(Cpu obj, Guid id)
        {
            if (await _cpuServices.UpdateCpu(obj, id))
            {
                return Ok("Sửa thành công");
            }
            else return NotFound("Sửa thất bại");
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteCpu(Guid id)
        {
            if (await _cpuServices.DeleteCpu(id))
            {
                return Ok("Xóa thành công");
            }
            else return NotFound("Xóa thất bại");
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetCpuById(Guid id)
        {
            if(await _cpuServices.GetCpuById(id) == null)
            {
                return NotFound("Không tìm thấy");
            }
            else return Ok(await _cpuServices.GetCpuById(id));
        }
    }
}
