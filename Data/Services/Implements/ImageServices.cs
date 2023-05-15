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
    public class ImageServices : IImageServices
    {
        private readonly ApplicationDbContext context;
        public ImageServices()
        {
            context = new ApplicationDbContext();
        }

        public async Task<bool> AddAsync(Image image)
        {
            try
            {
                image.Id = Guid.NewGuid();
                await context.AddAsync(image);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var listObj = await context.Images.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                context.Remove(temp);
                await Task.FromResult<Image>(context.Images.Remove(temp).Entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Image>> GetAllImageAsync()
        {
            var listObj = await context.Images.ToListAsync();
            if (listObj == null)
            {
                return new();
            }
            return listObj;
        }

        public async Task<Image> GetByIdAsync(Guid id)
        {
            var listObj = await context.Images.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Id == id);

            if (temp == null)
            {
                return new Image();
            }
            return temp;
        }

        public async Task<List<string>> GetByMaAsync(string ma)
        {
            var listObj = await context.Images.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Equals(ma));

            if (listObj == null)
            {
                return null;
            }
            return new List<string>();
        }

        public async Task<bool> UpdateAsync(Image image, Guid id)
        {
            try
            {
                var listObj = await context.Images.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);
                    
                context.Remove(temp);
                await Task.FromResult<Image>(context.Images.Update(temp).Entity);
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
