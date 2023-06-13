using Data.Services.Implements;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserServices _userServices = new UserServices();
        [HttpGet]
        public async Task<IActionResult> Login(string username, string password)
        {
            //if (await _userServices.IsAdministrator(username, password))
            //{
            //    var tokenString = _userServices.GenerateTokenString(username, password);
            //    return Ok(tokenString);

            //}
            //else if (await _userServices.IsClient(username, password))
            //{
            //    return Ok("Client");

            //}
            return BadRequest("Sai");

        }
    }
}
