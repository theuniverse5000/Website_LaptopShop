using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IVoucherServices
    {
        Task<bool> CreateVoucher(Voucher p);
        Task<bool> UpdateVoucher(Voucher p, Guid id);
        Task<bool> DeleteVoucher(Guid id);
        Task<List<Voucher>> GetAllVouchers();
        Task<Voucher> GetVoucherById(Guid id);
        Task<bool> GetVoucherByMa(string ma);
    }
}
