using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CreateRam(Ram r)
        {
            try
            {
                if (r == null) return false;
                else
                {
                    await context.Rams.AddAsync(r);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRam(Guid id)
        {
            try
            {
                var ram = await context.Rams.FindAsync(id);
                if(ram == null) return false;
                else
                {
                    context.Rams.Remove(ram); 
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Ram>> GetAllRams()
        {
            return await context.Rams.ToListAsync();
        }

        public async Task<Ram> GetRamById(Guid id)
        {
            return await context.Rams.FindAsync(id);
        }

        public async Task<bool> GetRamByMa(string ma)
        {
            var ram = await context.Rams.ToListAsync();
            var r = ram.FirstOrDefault(x => x.Ma == ma);
            if (r == null) return false;
            else return true;
        }

        public async Task<bool> UpdateRam(Ram r, Guid id)
        {
            try
            {
                if (r == null) return false;
                else
                {
                    var ram = context.Rams.Find(id);
                    //ram.Ma = r.Ma;
                    ram.MoTa = r.MoTa;
                    ram.ThongSo = r.ThongSo;
                    ram.SoKheCam = r.SoKheCam;
                    context.Rams.Update(ram);
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
