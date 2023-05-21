using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Data.Services.Implements;
using Data.Services.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        ApplicationDbContext context;
        IScreenServices _ScreenSV;
        public ScreenController()
        {
            context = new ApplicationDbContext();
            _ScreenSV = new ScreenServices();
        }
        // GET: api/<ScreenController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Screen>>> GetScreen()
        {
            if (context == null)
            {
                return NotFound();
            }
            return await _ScreenSV.GetAllScreen();
        }

        // GET api/<ScreenController>/5
        [HttpGet("{id}")]

        // POST api/<ScreenController>
        [HttpPost]
        public async Task<ActionResult> Create(Screen screen)
        {
            if (await _ScreenSV.Add(screen))
            {
                return Ok("Bạn đã thêm thành công");
            }
            else return NotFound("Không thể thêm được");
        }

        // PUT api/<ScreenController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(Screen screen, Guid id)
        {
            if (await _ScreenSV.Update(screen, id))
            {
                return Ok("Bạn đã thêm thành ");
            }
            else return NotFound("Không thể thêm được");
        }

        // DELETE api/<ScreenController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _ScreenSV.Delete(id))
            {
                return Ok("Bạn đã xóa thành công");
            }
            return NotFound("Không thể xóa được");
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetId(Guid id)
        {
            if (await _ScreenSV.GetById(id) == null)
            {
                return NotFound("Không có kết quả");
            }
            else return Ok(await _ScreenSV.GetById(id));
        }
    }
}
