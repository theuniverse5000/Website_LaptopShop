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
        ApplicationDbContext context;
        IHardDriveServices HDservices;

        public HardDriveController()
        {
            context = new ApplicationDbContext();
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

        // GET api/<HardDriveController>/5
        [HttpGet("{id}")]


        // POST api/<HardDriveController>
        [HttpPost]
        public async Task<ActionResult> CreateHD(HardDrive hardDrive)
        {
            if (await HDservices.Add(hardDrive))
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
