using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Data.Services.Implements
{
    public class HardDriveServices : IHardDriveServices
    {
        ApplicationDbContext context;
        public HardDriveServices()
        {
            context = new ApplicationDbContext();
        }
        public async Task<bool> Add(HardDrive harddrive)
        {
            try
            {
                var h = context.HardDrives.FirstOrDefault(x => x.Id == harddrive.Id);
               
                h.Id = Guid.NewGuid();
                h.Ma = harddrive.Ma;
                h.ThongSo = harddrive.ThongSo;
                h.MoTa = harddrive.MoTa;
                await context.AddAsync(harddrive);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var listObj = await context.HardDrives.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                context.Remove(temp);
                await Task.FromResult<HardDrive>(context.HardDrives.Remove(temp).Entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<HardDrive>> GetAllHardDrive()
        {
            var listObj = await context.HardDrives.ToListAsync();
            if (listObj == null)
            {
                return new();
            }
            return listObj;
        }

        public async Task<HardDrive> GetById(Guid id)
        {
            var listObj = await context.HardDrives.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Id == id);

            if (temp == null)
            {
                return new HardDrive();
            }
            return temp;
        }

        public async Task<List<string>> GetByName(string name)
        {
            var listObj = await context.HardDrives.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Equals(name));

            if (listObj == null)
            {
                return null;
            }
            return new List<string>();
        }

        public async Task<bool> Update(HardDrive harddrive, Guid id)
        {
            try
            {
                
                var h = context.HardDrives.FirstOrDefault(v => v.Id == id);
                h.ThongSo = harddrive.ThongSo;
                h.MoTa = harddrive.MoTa;
                context.Update(h);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
