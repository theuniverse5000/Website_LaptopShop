using Data.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Implements
{
    public class RamServices : IRamServices
    {
        ApplicationDbContext context;
        public RamServices()
        {
            context = new ApplicationDbContext();
        }
        public bool CreateRam(Ram r)
        {
            try
            {
                context.Rams.Add(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRam(Guid id)
        {
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var ram = context.Rams.Find(id);
                context.Rams.Remove(ram);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ram> GetAllRams()
        {
            return context.Rams.ToList();
        }

        public Ram GetRamById(Guid id)
        {
            return context.Rams.FirstOrDefault(p => p.Id == id);
        }

        public List<Ram> GetRamByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRam(Ram r)
        {
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var ram = context.Rams.Find(r.Id);
                ram.Ma = r.Ma;
                ram.ThongSo = r.ThongSo;
                ram.SoKheCam = r.SoKheCam;
                ram.MoTa = r.MoTa;
                // Có thể sửa thêm thuộc tính
                context.Rams.Update(ram);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
