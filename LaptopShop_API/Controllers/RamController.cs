using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        //  ApplicationDbContext _dbContext;
        public RamController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ram>>> GetRam()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.Rams.ToListAsync();
        }
        [HttpPost]
        public ActionResult CreateRam(Ram rv)
        {
            Ram r = new Ram();
            r.Id = Guid.NewGuid();
            r.Ma = rv.Ma;
            r.ThongSo = rv.ThongSo;
            _dbContext.Rams.Add(r);
            _dbContext.SaveChanges();
            return Ok("Thêm thành công");
        }
        [HttpPut("id")]
        public ActionResult UpdateRam(Ram rv)
        {
            var r = _dbContext.Rams.Find(rv.Id);
            r.ThongSo = rv.ThongSo;
            r.Ma = rv.Ma;
            _dbContext.Rams.Update(r);
            _dbContext.SaveChanges();
            return Ok("Bạn đã cập nhật thành công");
        }
        [HttpDelete("id")]
        public ActionResult DeleteRam(Guid Id)
        {
            var r = _dbContext.Rams.Find(Id);
            _dbContext.Rams.Remove(r);
            _dbContext.SaveChanges();
            return Ok("Bạn đã xóa thành công");
        }
    }
}
