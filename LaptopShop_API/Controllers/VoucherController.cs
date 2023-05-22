﻿using Data.Models;
using Data.Services.Implements;
using Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherServices _voucherServices;
        public VoucherController(IVoucherServices voucherServices)
        {
            _voucherServices = voucherServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetALlVoucher()
        {
            return Ok(await _voucherServices.GetAllVouchers());
        }
        [HttpPost]
        public async Task<ActionResult> CreateVoucher(Voucher vc)
        {
            if (await _voucherServices.GetVoucherByMa(vc.Ma))
            {
                return NotFound("Đã có mã");
            }
            else if (await _voucherServices.CreateVoucher(vc))
            {
                return Ok("Thêm thành công");
            }
            else
            {
                return NotFound("Thêm thất bại");
            }
        }
        [HttpPut("id")]
        public async Task<ActionResult> UpdateVoucher(Voucher vc, Guid id)
        {
            if (await _voucherServices.UpdateVoucher(vc, id))
            {
                return Ok("Sửa thành công");
            }
            else return NotFound("Sửa thất bại");
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteVoucher(Guid id)
        {
            if (await _voucherServices.DeleteVoucher(id))
            {
                return Ok("Xóa thành công");
            }
            else return NotFound("Xóa thất bại");
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetVoucherById(Guid id)
        {
            if (await _voucherServices.GetVoucherById(id) == null)
            {
                return NotFound("Không tìm thấy");
            }
            else return Ok(await _voucherServices.GetVoucherById(id));
        }
    }
}
