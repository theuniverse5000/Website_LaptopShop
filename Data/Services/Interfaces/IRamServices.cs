using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IRamServices
    {
        Task<bool> CreateRam(Ram r);
        Task<bool> UpdateRam(Ram r, Guid id);
        Task<bool> DeleteRam(Guid id);
        Task<List<Ram>> GetAllRams();
        Task<Ram> GetRamById(Guid id);
        Task<bool> GetRamByMa(string ma);
    }
}
