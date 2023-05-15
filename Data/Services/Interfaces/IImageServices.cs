using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IImageServices
    {
        public Task<List<Image>> GetAllImageAsync();
        public Task<bool> UpdateAsync(Image image, Guid id);
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> AddAsync(Image image);
        public Task<Image> GetByIdAsync(Guid id);
        public Task<List<string>> GetByMaAsync(string ma);

    }
}
