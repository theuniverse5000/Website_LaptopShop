using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IImageServices
    {
        public Task<List<Image>> GetAllImageAsync();
        public Task<bool> UpdateAsync(Image image);
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> AddAsync(Image image);
        public Task<Image> GetByIdAsync(Guid id);
        public Task<bool> CheckMa(string ma);

    }
}
