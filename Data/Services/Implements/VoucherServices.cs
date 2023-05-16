using Data.Models;
using Data.Services.Interfaces;

namespace Data.Services.Implements
{
    internal class VoucherServices : IVoucherServices
    {
        ApplicationDbContext _context;
        public VoucherServices()
        {
            _context = new ApplicationDbContext();
        }
        public bool CreateVoucher(Voucher p)
        {
            try
            {
                _context.Vouchers.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteVoucher(Guid id)
        {
            try
            {
                dynamic voucher = _context.Vouchers.Find(id);
                _context.Vouchers.Remove(voucher);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Voucher> GetAllVouchers()
        {
            return _context.Vouchers.ToList();
        }

        public Voucher GetVoucherById(Guid id)
        {
            return _context.Vouchers.FirstOrDefault(p => p.ID == id);
        }

        public List<Voucher> GetVoucherByName(string name)
        {
            return _context.Vouchers.Where(p => p.Equals(name)).ToList();
        }

        public bool UpdateVoucher(Voucher p)
        {
            try
            {
                var voucher = _context.Vouchers.Find(p.ID);
                voucher.Ma = p.Ma;
                voucher.Name = p.Name;
                voucher.StartDay = p.StartDay;
                voucher.EndDay = p.EndDay;
                voucher.GiaTri = p.GiaTri;
                voucher.SoLuong = p.SoLuong;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
