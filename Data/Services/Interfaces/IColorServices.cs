using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IColorServices
    {
        Task<List<Color>> GetAllColor();
        Task<bool> Update(Color Color, Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Add(Color Color);
        Task<Color> GetById(Guid id);
        Task<List<string>> GetByName(string name);
        
    }
}
