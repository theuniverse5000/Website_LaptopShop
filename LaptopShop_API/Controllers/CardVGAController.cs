using Data.Models;
using Data.Services.Implements;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardVGAController : ControllerBase
    {
        private readonly ICardVGAServices _cardServices;
        public CardVGAController()
        {
            _cardServices = new CardVGAServices();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCardVGA() 
        {
            var listCardVGA = await _cardServices.GetAllCardVGAs();
            return Ok(listCardVGA);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCardVGA(CardVGA cardVGA) 
        {
            if (await _cardServices.GetCardVGAByMa(cardVGA.Ma))
            {
                return NotFound("Đã có mã");
            }
            else if (await _cardServices.CreateCardVGA(cardVGA))
            {
                return Ok("Thêm Thành Công");
            }
            else
            {
                return NotFound("Thêm Thất Bại");
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCardVGA(CardVGA cardVGA)
        {
            if (await _cardServices.UpdateCardVGA(cardVGA, cardVGA.Id))
            {
                return Ok("Sửa thành công");
            }
            else
            {
                return NotFound("Sửa thất bại");
            }
        }
        [HttpDelete ("id")]
        public async Task<ActionResult> DeleteCardVGA(Guid id) 
        {
            if (await _cardServices.DeleteCardVGA(id))
            {
                return Ok("Xóa thành công");
            }
            else return NotFound("Xóa thất bại");
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetCardVGAByID(Guid id)
        {
            if (await _cardServices.GetCardVGAById(id) == null)
            {
                return NotFound("Không tìm thấy");
            }else return Ok(await _cardServices.GetCardVGAById(id));
        }
    }
}
