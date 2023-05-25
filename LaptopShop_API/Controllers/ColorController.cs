using Data.Models;
using Data.Services.Implements;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using System.Linq;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorServices _colorService;

        public ColorController(IColorServices colorService)
        {
            _colorService = colorService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _colorService.GetAllColor());
        }

        [HttpPost]
        public async Task<ActionResult> Create(Color color)
        {
            if (await _colorService.CheckMa(color.Ma))
            {
                return BadRequest("ma da ton tai");
            }
            else if (color != null)
            {
                if (await _colorService.Add(color))
                {
                    return Ok("them thanh cong");
                }
                else return NotFound("that bai");
            }
            else return BadRequest("khong ton tai");

        }


        [HttpPut("id")]
        public async Task<ActionResult> Edit(Color color, Guid id)
        {
            if (color != null)
            {
                if (await _colorService.Update(color, id))
                {
                    return Ok("thanh cong");
                }
                else return NotFound("that bai");
            }
            else return BadRequest("khong ton tai");

        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _colorService.Delete(id))
            {
                return Ok("thanh cong");
            }
            return NotFound("that bai");
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetId(Guid id)
        {
            if (await _colorService.GetById(id) == null)
            {
                return NotFound("ko tim thay");
            }
            else return Ok(await _colorService.GetById(id));
        }
    }
}
