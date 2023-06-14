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
        [HttpGet("admin")]
        public async Task<bool> LoginAdmin(string username, string password)
        {
            if (await _userServices.IsAdministrator(username, password))
            {
                return true;

            }

            return false;

        }
        [HttpGet("client")]
        public async Task<bool> LoginClent(string username, string password)
        {
            if (await _userServices.IsClient(username, password))
            {
                return true;

            }
            return false;

        }
    }
}
