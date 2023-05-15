using Data.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Implements
{
    public class CpuServices : ICpuServices
    {
        ApplicationDbContext context;
        public CpuServices()
        {
            context = new ApplicationDbContext();
        }
        public bool CreateCpu(Cpu c)
        {
            try
            {
                context.Cpus.Add(c);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCpu(Guid id)
        {
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var cpu = context.Cpus.Find(id);
                context.Cpus.Remove(cpu);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cpu> GetAllCpus()
        {
            return context.Cpus.ToList();
        }

        public Cpu GetCpuById(Guid id)
        {
            return context.Cpus.FirstOrDefault(p => p.Id == id);
            // return context.Products.SingleOrDefault(p => p.Id == id);
        }

        public List<Cpu> GetCpuByName(string name)
        {
            return context.Cpus.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateCpu(Cpu c)
        {
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var cpu = context.Cpus.Find(c.Id);
                cpu.Ma = c.Ma;
                cpu.Name = c.Name;
                // Có thể sửa thêm thuộc tính
                context.Cpus.Update(cpu);
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
