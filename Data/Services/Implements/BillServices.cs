﻿using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class BillServices : IBillServices
    {
        ApplicationDbContext _dbContext;
        public BillServices()
        {
            _dbContext = new ApplicationDbContext();
        }

        public async Task<bool> CreateBill(Bill obj)
        {
            try
            {
                await _dbContext.Bills.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBill(Guid id)
        {
            try
            {
                var listBill = await _dbContext.Bills.ToListAsync();
                var bill = listBill.FirstOrDefault(t => t.Id == id);
                if (bill != null)
                {
                    //_dbContext.Bills.Attach(bill);
                    _dbContext.Bills.Remove(bill);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Task<List<BillView>> GetAllBillJoinFull()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Bill>> GetAllBills()
        {
            return await _dbContext.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillById(Guid id)
        {
            return await _dbContext.Bills.FindAsync(id);
        }

        public async Task<bool> IsMaBill(string ma)
        {
            var listBill = await _dbContext.Bills.ToListAsync();
            var b = listBill.FirstOrDefault(x => x.Ma == ma);
            if (b != null)
            {
                return true;
            }
            else return false;


        }

        public async Task<bool> UpdateBill(Bill obj)
        {
            try
            {
                var b = _dbContext.Bills.Find(obj.Id);
                b.HoTenKhachHang = obj.HoTenKhachHang;
                b.DiaChiKhachHang = obj.DiaChiKhachHang;
                b.SdtKhachHang = obj.SdtKhachHang;
                b.Status = obj.Status;
                _dbContext.Bills.Update(b);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatusBill(Guid id)
        {
            try
            {
                var b = await _dbContext.Bills.FindAsync(id);
                b.Status = 1;
                _dbContext.Bills.Update(b);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //    public bool CreateBill(Bill thao)
        //    {
        //        try
        //        {
        //            _dbContext.Bills.Add(thao);
        //            _dbContext.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }

        //    }

        //    public bool DeleteBill(Guid id)
        //    {
        //        try
        //        {
        //            var thao = _dbContext.Bills.Find(id);
        //            _dbContext.Bills.Remove(thao);
        //            _dbContext.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }

        //    public List<BillView> GetAllBillJoinFull()
        //    {
        //        List<BillView> bills = new List<BillView>();
        //        bills = (

        //                 from a in _dbContext.Bills.ToList()
        //                 join b in _dbContext.BillDetails.ToList() on a.Id equals b.IdBill
        //                 join c in _productDetailServices.GetAllProductDetailsPhunData() on b.IdProductDetails equals c.Id
        //                 join d in _dbContext.Vouchers.ToList() on a.VoucherId equals d.ID
        //                 select new BillView
        //                 {
        //                     IdBill = a.Id,
        //                     MaBill = a.Ma,
        //                     UserId = a.UserId,
        //                     CreateDate = a.CreateDate,
        //                     SdtKhachHang = a.SdtKhachHang,
        //                     HoTenKhachHang = a.HoTenKhachHang,
        //                     DiaChiKhachHang = a.DiaChiKhachHang,
        //                     Status = a.Status,
        //                     Quantity = b.Quantity,
        //                     Price = b.Price,
        //                     IdBillDetail = b.Id,
        //                     NameProduct = c.NameProduct,
        //                     NameCpu = c.NameCpu,
        //                     ThongSoRam = c.ThongSoRam,
        //                     ThongSoHardDrive = c.ThongSoHardDrive,
        //                     MaVoucher = d.Ma,
        //                     GiaTriVoucher = d.GiaTri
        //                 }
        //          ).ToList();
        //        return bills;
        //    }

        //    public List<Bill> GetAllBills()
        //    {
        //        return _dbContext.Bills.ToList();
        //    }

        //    public Bill GetBillById(Guid id)
        //    {
        //        return _dbContext.Bills.Find(id);
        //    }

        //    public bool UpdateBill(Bill thao)
        //    {
        //        try
        //        {
        //            var linh = _dbContext.Bills.Find(thao.Id);
        //            linh.HoTenKhachHang = thao.HoTenKhachHang;
        //            linh.DiaChiKhachHang = thao.DiaChiKhachHang;
        //            linh.SdtKhachHang = thao.SdtKhachHang;
        //            linh.Status = thao.Status;
        //            _dbContext.Bills.Update(linh);
        //            _dbContext.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }

        //    public bool UpdateStatusBill(Guid Id)
        //    {
        //        try
        //        {
        //            var linh = _dbContext.Bills.Find(Id);
        //            linh.Status = 1;
        //            _dbContext.Bills.Update(linh);
        //            _dbContext.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }
    }
}
