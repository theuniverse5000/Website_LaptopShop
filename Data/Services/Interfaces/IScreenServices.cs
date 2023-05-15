using System;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IScreenServices
    {
        Task<List<Screen>> GetAllScreen();
        Task<bool> Update(Screen screen, Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Add(Screen screen);
        Task<Screen> GetById(Guid id);
        Task<List<string>> GetByName(string name);
    }
}
