using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


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

        public async Task<bool> CheckMa(string ma)
        {
            var temp = await context.Images.ToListAsync();
            var obj = temp.FirstOrDefault(v => v.Ma == ma);
            if (obj == null)
            {
                return false;
            }
            return true;
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
            return await context.Images.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> UpdateAsync(Image image)
        {
            try
            {
                var listObj = await context.Images.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == image.Id);
                temp.LinkImage = image.LinkImage;
                temp.IdProductDetail = image.IdProductDetail;
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
