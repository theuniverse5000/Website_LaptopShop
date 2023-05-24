using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.Services.Interfaces;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;
        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _roleServices.GetAllRoles());
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if (await _roleServices.GetById(id) == null)
            {
                return NotFound("khong ton tai");
            }
            else return Ok(await _roleServices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Role role)
        {
            if (await _roleServices.GetByName(role.RoleName))
            {
                return BadRequest("ten da ton tai");
            }
            else if (role != null)
            {
                if (await _roleServices.Add(role))
                {
                    return Ok("thanh cong");
                }
                else return NotFound("that bai");
            }
            else return BadRequest("khong ton tai");
        }

        [HttpPut("id")]
        public async Task<ActionResult> Update(Role role, Guid id)
        {
            if (role != null)
            {
                if (await _roleServices.Update(role, id))
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
            if (await _roleServices.Delete(id))
            {
                return Ok("thanh cong");
            }
            else return NotFound("that bai");
        }


    }
}
