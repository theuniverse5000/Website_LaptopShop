using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class VoucherServices : IVoucherServices
    {
        private readonly ApplicationDbContext _dbcontext;
        public VoucherServices()
        {
            _dbcontext= new ApplicationDbContext();
        }
        public async Task<bool> CreateVoucher(Voucher p)
        {
            try
            {
                if (p == null)
                {
                    return false;
                }
                else
                {
                    await _dbcontext.Vouchers.AddAsync(p);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteVoucher(Guid id)
        {
            try
            {
                var listVoucher = await _dbcontext.Vouchers.ToListAsync();
                var vc = listVoucher.FirstOrDefault(p => p.ID == id);

                _dbcontext.Remove(vc);
                await Task.FromResult<Voucher>(_dbcontext.Vouchers.Remove(vc).Entity);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Voucher>> GetAllVouchers()
        {
            return await _dbcontext.Vouchers.ToListAsync();
        }

        public async Task<Voucher> GetVoucherById(Guid id)
        {
            return await _dbcontext.Vouchers.FindAsync(id);
        }

        public async Task<bool> GetVoucherByMa(string ma)
        {
            var vc = await _dbcontext.Vouchers.ToListAsync();
            var v = vc.FirstOrDefault(x => x.Ma == ma);
            if (v == null)
            {
                return false;
            }
            else return true;
        }

        public async Task<bool> UpdateVoucher(Voucher p, Guid id)
        {
            try
            {
                if (p == null)
                {
                    return false;
                }
                else
                {
                    var vc = _dbcontext.Vouchers.Find(p.ID);
                    
                    vc.Name= p.Name;
                    vc.StartDay= p.StartDay;
                    vc.EndDay= p.EndDay;
                    vc.GiaTri = p.GiaTri;
                    vc.SoLuong = p.SoLuong;
                    _dbcontext.Vouchers.Update(vc);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
