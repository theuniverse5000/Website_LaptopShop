using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Services.Implements
{
    public class CpuServices : ICpuServices
    {
        ApplicationDbContext context;
        public CpuServices()
        {
            context = new ApplicationDbContext();
        }

        public async Task<bool> CreateCpu(Cpu c)
        {
            try
            {
                if (c == null) return false;
                else
                {
                    await context.Cpus.AddAsync(c);
                    await context.SaveChangesAsync();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCpu(Guid id)
        {
            try
            {
                var cpu = await context.Cpus.FindAsync(id);
                if (cpu == null) return false;
                else
                {
                    context.Cpus.Remove(cpu);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Cpu>> GetAllCpus()
        {
            return await context.Cpus.ToListAsync();
        }

        public async Task<Cpu> GetCpuById(Guid id)
        {
            return await context.Cpus.FindAsync(id);
        }

        public async Task<bool> GetCpuByMa(string ma)
        {
            var cpu = await context.Cpus.ToListAsync();
            var t = cpu.FirstOrDefault(x => x.Ma == ma);
            if (t == null) return false;
            else return true;
        }

        public async Task<bool> UpdateCpu(Cpu c, Guid id)
        {
            try
            {
                if (c == null) return false;
                else
                {
                    var cpu = context.Cpus.Find(c.Id);
                    cpu.Name = c.Name;
                    //cpu.Ma = c.Ma;
                    cpu.ThongSo = c.ThongSo;
                    context.Cpus.Update(cpu);
                    await context.SaveChangesAsync();
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
