using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Services.Implements
{
    public class ColorServices:IColorServices
    {
        private readonly ApplicationDbContext context;
        public ColorServices()
        {
            context = new ApplicationDbContext();
        }

        public async Task<bool> Add(Color Color)
        {

            try
            {
                Color.Id = Guid.NewGuid();
                await context.AddAsync(Color);
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
                var listObj = await context.Colors.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                context.Remove(temp);
                await Task.FromResult<Color>(context.Colors.Remove(temp).Entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Color>> GetAllColor()
        {
            var listObj = await context.Colors.ToListAsync();
            if (listObj == null)
            {
                return new();
            }
            return listObj;
        }

        public async Task<Color> GetById(Guid id)
        {
            var listObj = await context.Colors.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Id == id);

            if (temp == null)
            {
                return new Color();
            }
            return temp;
        }

        public async Task<List<string>> GetByName(string name)
        {
            var listObj = await context.Colors.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Equals(name));

            if (listObj == null)
            {
                return null;
            }
            return new List<string>();
        }

        public async Task<bool> Update(Color Color, Guid id)
        {
            try
            {
                var listObj = await context.Colors.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                context.Remove(temp);
                await Task.FromResult<Color>(context.Colors.Update(temp).Entity);
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
