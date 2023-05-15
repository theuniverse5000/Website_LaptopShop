using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    internal interface IVoucherServices
    {
        public bool CreateVoucher(Voucher p);
        public bool UpdateVoucher(Voucher p);
        public bool DeleteVoucher(Guid id);
        public List<Voucher> GetAllVouchers();
        public Voucher GetVoucherById(Guid id);
        public List<Voucher> GetVoucherByName(string name);
    }
}
