using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.Services.Implements;
using Data.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardDriveController : ControllerBase
    {
        IHardDriveServices HDservices;

        public HardDriveController()
        {
            HDservices = new HardDriveServices();
        }
        // GET: api/<HardDriveController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<HardDrive>>> GetHD()
        {
            if (HDservices == null)
            {
                return NotFound();
            }
            return await HDservices.GetAllHardDrive();
        }


        // POST api/<HardDriveController>
        [HttpPost]
        public async Task<ActionResult> CreateHD(HardDrive hardDrive)
        {
            var listHD = await HDservices.GetAllHardDrive();
            if (!listHD.Any(p => p.Ma == hardDrive.Ma))
            {
                return BadRequest("Mã đã tồn tại");
            }else if (await HDservices.Add(hardDrive))
            {
                return Ok("Bạn đã thêm thành công");
            }
            else return NotFound("Không thể thêm được");
        }

        // PUT api/<HardDriveController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(HardDrive hardDrive, Guid id)
        {
            if (await HDservices.Update(hardDrive, id))
            {
                return Ok("Bạn đã sửa thành công");
            }
            else return NotFound("Không thể sửa được");
        }

        // DELETE api/<HardDriveController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await HDservices.Delete(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            return NotFound("Không thể xóa được");
        }
        
       
    }
}
