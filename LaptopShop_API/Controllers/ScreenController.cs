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
        IScreenServices _ScreenSV;
        public ScreenController()
        {
            _ScreenSV = new ScreenServices();
        }
        // GET: api/<ScreenController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Screen>>> GetScreen()
        {
            if (_ScreenSV == null )
            {
                return NotFound();
            }
            return await _ScreenSV.GetAllScreen();
        }

       
        // POST api/<ScreenController>
        [HttpPost]
        public async Task<ActionResult> Create(Screen screen)
        {
            var listScreen = await _ScreenSV.GetAllScreen();
            if (listScreen.Any( p=> p.Ma == screen.Ma)){
                return BadRequest("Mã đã tồn tại");
            }
            else if (await _ScreenSV.Add(screen))
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
                return Ok("Bạn đã sửa thành cônh");
            }
            else return NotFound("Không thể sửa được");
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
